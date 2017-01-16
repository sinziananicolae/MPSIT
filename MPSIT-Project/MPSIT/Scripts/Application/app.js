(function () {
    "use strict";

    angular.module("app", [
            "ngRoute",
            "ngSanitize",
            "ngResource",
            "ngAnimate",
            "ui.bootstrap",
            "directivesTheme",
            "services",
             "toastr"
        ]).config(["$routeProvider", function($routeProvider) {
			$routeProvider.when('/', {
				templateUrl : './Scripts/Application/Home/home.html',
				controller : 'HomeController'
			}).otherwise({
				redirectTo : '/'
			});
        }]).controller("GreetingController", ["$scope", "UserService", "toastr", function ($scope, userService, toastr) {
            $scope.loading = true;

            userService.get(function (response) {
                if (!response.success) {
                    toastr.error(response.message);
                    window.location.href = "/Account/LogIn";
                    return;
                }
                else {
                    $scope.user = response.data;
                }
                $scope.loading = false;
            });

            $scope.logOff = function () {
                window.location.href = "/Account/LogOff";
            }
        }]);
})();
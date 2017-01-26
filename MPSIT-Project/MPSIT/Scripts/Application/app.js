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
            "toastr",
            "uiGmapgoogle-maps",
            "chart.js"
        ]).config(["$routeProvider", function($routeProvider) {
			$routeProvider.when('/home', {
				templateUrl : './Scripts/Application/Home/home.html',
				controller : 'HomeController'
			}).when('/apiary/:id?', {
			    templateUrl: './Scripts/Application/Apiary/apiary.html',
			    controller: 'ApiaryController'
			}).when('/hive/:id?', {
			    templateUrl: './Scripts/Application/Hive/hive.html',
			    controller: 'HiveController'
			}).when('/map', {
			    templateUrl: './Scripts/Application/Map/map.html',
			    controller: 'MapController'
			}).when('/hive-file/:hiveId/:id?', {
			    templateUrl: './Scripts/Application/HiveFile/hiveFile.html',
			    controller: 'HiveFileController'
			}).otherwise({
				redirectTo : '/home'
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

            $scope.getReport = function () {
                userService.get({param: 'report'}, function (response) {
                    
                });
            }
        }]);
})();
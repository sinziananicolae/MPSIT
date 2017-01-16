(function () {
    "use strict";

    angular.module("app", [
            "ngRoute",
            "ngSanitize",
            "ngResource",
            "ngAnimate",
            "ui.bootstrap",
            "directivesTheme",
            "services"
        ]).config(["$routeProvider", function($routeProvider) {
			$routeProvider.when('/', {
				templateUrl : './Scripts/Application/Home/home.html',
				controller : 'HomeController'
			}).otherwise({
				redirectTo : '/'
			});
		} ]);
})();
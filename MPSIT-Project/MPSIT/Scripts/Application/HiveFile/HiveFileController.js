(function () {
    "use strict";

    angular.module("app").controller("HiveFileController", ["$scope", "$routeParams", "HiveService", hiveFileController]);

    function hiveFileController($scope, $routeParams, HiveService) {
        $scope.currentHiveNo = $routeParams.hiveId;
        $scope.hiveFileId = $routeParams.id;

        $scope.hiveTypes = ["Strong", "Medium", "Weak", "Sick"];

        if ($scope.hiveFileId)
            HiveService.get({ param: "file", id: $scope.hiveFileId }, function (response) {
                $scope.hiveFile = response;
            });
        else
            $scope.hiveFile = {};

    }
}());
angular.module("gitiApp", []).
controller("homeController", ["$scope", "$timeout", "$interval", function ($scope, $timeout, $interval) {

    $scope.selectedStep = 1;

    $scope.init = function () {
        //alert('hello world');

        $interval(function () {
            if ($scope.selectedStep < 3) {
                $scope.selectedStep++
            } else {
                $scope.selectedStep = 1;
            }
        }, 5000);
    };

    $scope.init();
}]);
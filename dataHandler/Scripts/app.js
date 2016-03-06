angular.module("gitiApp", []).
controller("homeController", ["$scope", "$timeout", "$interval", function ($scope, $timeout, $interval) {

    $scope.selectedStep = 1;

}]);
var Initilise = function (url) {

    var app = angular.module("CustomerListApp", []);

    app.controller("CustomerListAppController", function ($scope, $http) {
        $scope.Get = function () {
            $http.get(url).success(function (result) {
                $scope.Customers = result;
            });
        };

        $scope.Form = {};

        $scope.FormMode = "Create";

        $scope.FormReset = function () {
            $scope.Form = {};
            $scope.FormMode = "Create";
            $scope.Get();
        }

        $scope.Submit = function () {
            var customer = $scope.Form;
            alert(customer);
            var mode = $scope.FormMode;

            if (mode === "Create") {
                $http.put(url).success(function (result) {
                    $scope.FormReset();
                });
            }
            else if (mode === "Update") {
                $http.post(url, customer).success(function (result) {
                    $scope.FormReset();
                });
            }
        };

        $scope.SetupForEdit = function (customer) {
            $scope.Form = customer;
            $scope.FormMode = "Update";
            alert(customer.DateOfBirth);
        }
    });
};
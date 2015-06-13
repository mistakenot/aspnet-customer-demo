var Initilise = function (url) {

    var app = angular.module("CustomerListApp", []);
    var httpSettings = {
        headers: {
            "Content-Type": "application/json"
        }
    };

    app.controller("CustomerListAppController", function ($scope, $http) {
        $scope.Get = function () {
            $http.get(url).success(function (result) {
                $scope.Customers = result;
            });
        };

        $scope.Form = {};

        $scope.Message = "";

        $scope.MessageColour = "green";

        $scope.FormMode = "Create";

        $scope.FormReset = function () {
            $scope.Form = {};
            $scope.FormMode = "Create";
            $scope.Get();
            $scope.Message = "";
        }

        $scope.OnFormSuccess = function () {
            $scope.FormReset();
            $scope.Message = "Successful";
        }

        $scope.OnFormError = function () {
            $scope.Message = "Error";
            $scope.MessageColour = "red";
            alert("An error has occurred. Please check your inputs and try again.");
        }

        $scope.Submit = function () {
            // TODO Ugly hack to get around ASP.NET not recognising request 
            //  body as json. If you send just the object, comes up null.
            var customer = "'" + JSON.stringify($scope.Form) + "'";
            var mode = $scope.FormMode;

            if (mode === "Create") {
                $http.put(url, customer, httpSettings).success(function (result) {
                    $scope.OnFormSuccess();
                }).error($scope.OnFormError);
            }
            else if (mode === "Update") {
                $http.post(url, customer, httpSettings).success(function (result) {
                    $scope.OnFormSuccess();
                }).error($scope.OnFormError);
            }
        };

        $scope.SetupForEdit = function (customer) {
            $scope.Form = customer;
            $scope.FormMode = "Update";
            $scope.Message = "";
        }
    });
};
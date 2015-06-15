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
                result.forEach(function (r) {
                    r.Age = function () {
                        var age = moment().diff(r.DateOfBirth, "years");
                        if (isNaN(age))
                            return "";
                        else
                            return age;
                    };
                    r.Forename = r.FirstName + " " + r.Surname;
                    r.YearOfBirth = function () {
                        return moment(r.DateOfBirth).format("YYYY");
                    };
                });
                $scope.Customers = result;
            }).error($scope.OnFormError);
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
            $scope.MessageColour = "green";
        }

        $scope.OnFormError = function () {
            $scope.Message = "Error";
            $scope.MessageColour = "red";
            alert("An error has occurred. Please check your inputs and try again.");
        }

        $scope.Submit = function () {

            var customer = {
                ID: $scope.Form.ID,
                FirstName: $scope.Form.FirstName,
                Surname: $scope.Form.Surname,
                Telephone: $scope.Form.Telephone,
                DateOfBirth: $scope.Form.DateOfBirth
            };

            // TODO Hack to get around ASP.NET not recognising request 
            //  body as json. If you send just the object, comes up null.
            var json = "'" + JSON.stringify(customer) + "'";
            var mode = $scope.FormMode;

            if (mode === "Create") {
                $http.put(url, json, httpSettings).success(function (result) {
                    $scope.OnFormSuccess();
                }).error($scope.OnFormError);
            }
            else if (mode === "Update") {
                $http.post(url, json, httpSettings).success(function (result) {
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
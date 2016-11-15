var app = angular.module("Tweeter", []);

app.controller("TwitCtrl", ['$scope', '$http', function ($scope, $http) {

    $scope.checkUser = (event) => {
        alert("Hello World");
        
        var username = $("#usernamefield");

        console.log(form);



        event.preventDefault();
        // $scope.UserURL;
        //console.log($scope.UserURL);
       // $http.get($scope.UserURL);
        //$http.post("/api/Response", { "Name": "Janelle", "Class": "E3" })
        //    .success(function (response) {
        //    })
        //    .error(function (response) {
        //        alert("Bad!");
        //    });
    }
}]);
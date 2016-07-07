
var app = angular.module('MyApp');


app.controller('BodyController', function ($scope, $http, $timeout) {
    $scope.rowCollection = [];

    var AmazingWallpaper = { img: "http://wallpapercave.com/wp/TSlZ57J.jpg" };
    $scope.wallpaper = AmazingWallpaper;

    console.log("$Scope -> wallpaper: " + $scope.wallpaper.img);
});

//app.controller('safeCtrl', ['$scope', '$http', '$timeout', '$interval', function ($scope, $http, $timeout, $interval) {

//    var DataToAlert;

//    pollData();

//    function pollData() {
        
//        var collection = [];

//        $interval(function () {

//            $http.get("/Home/GetVacancyList").then(function (result) {

//                angular.forEach(result.data, function (item, key) {
//                    console.log("DataKey: " + key + " DataValue: " + item);
//                    console.log("DataKey: " + key + "Company: " + item.Company);

//                    var row = { Title: item.Title, Company: item.Company, Salary: item.Salary }

//                    console.log("Row: " + row + " Row -> Title: " + row.Title +  " Row -> Company: " + row.Company + " Row -> Salary: " + row.Salary);
//                    collection.push(row);
//                });

//                $scope.rowCollection = collection;
//            });

//        }, 20000);
//    }
//}]);
 

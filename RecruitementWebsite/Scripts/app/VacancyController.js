
var app = angular.module('MyApp', ['smart-table', 'ui.bootstrap'])
{
}

//INIT the body controller
app.controller('BodyController', function ($scope, $http, $timeout) {
    $scope.rowCollection = [];

    //$scope.refreshData = function () {
    //    $http.get("/Home/GetVacancyList").then(function (response) {
    //        alert('Refreshing data...!');
    //        alert('data: ' + response.data);

    //        angular.forEach(response.data, function (value, key) {

    //            alert('Foreach entered: ' + 'value: ' + value + 'key: ' + key);
    //            $scope.rowCollection.push(value[key]);
    //        });
    //    });
    //    console.log(response);
    //}

    //$scope.refreshData();
    //$timeout($scope.refreshData, 900000);

});

//app.controller('VacancyListController', function ($scope) {
//    $scope.vacancyList = [{ id: 1 }, { id: 2 }];
//});

//app.controller('ButtonsCtrl', function ($scope) {
//    $scope.singleModel = 1;

//    $scope.radioModel = 'Middle';

//    $scope.checkModel = {
//        left: false,
//        middle: true,
//        right: false
//    };s

//    $scope.checkResults = [];

//    $scope.$watchCollection('checkModel', function () {
//        $scope.checkResults = [];
//        angular.forEach($scope.checkModel, function (value, key) {
//            if (value) {
//                $scope.checkResults.push(key);
//            }
//        });
//    });
//});

app.controller('safeCtrl', function ($scope, $http, $timeout) {
    $scope.GetData = function () {

        $http.get("/Home/GetVacancyList").then(function (response) {
            alert('Succes!');
            alert('data: ' + response.data);

            var alertValue = JSON.stringify(response.data);
            alert(alertValue);

            var i = 0;
            angular.forEach(response.data, function (value, key) {
                var valueString = JSON.stringify(value);

                angular.forEach(valueString, function (value, key) {
                    alert('Value of VacancyModel: ' + value);   
                });
                //var what = valueString.get('title');
                //alert('What??');

                //alert(valueString);
                //i++;
                //$scope.rowCollection.push(valueString[i]);
            });



            alert('This is the row collection for now: ' + $scope.rowCollection);

            //var i = 0;
            //angular.forEach(response.data, function (value, key) {
            //    alert("Value" + value.data);
            //    var valueString = JSON.stringify(value);
            //    alert(valueString);
            //    i++;
            //    alert('Foreach entered: ' + 'value: ' + value + 'key: ' + i);
            //    $scope.rowCollection.push(value[key]);
            //});
        });
    }
});
 

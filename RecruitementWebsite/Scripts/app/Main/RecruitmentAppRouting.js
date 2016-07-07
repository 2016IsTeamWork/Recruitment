
var MyApp = angular.module('MyApp');

// configure our routes
MyApp.config(function ($routeProvider) {
    $routeProvider

        // route for the home page
        .when('/', {
            templateUrl: 'Scripts/app/HTMLPages/home.html',
            controller: 'mainController'
        })

        // route for the about page
        .when('/about', {
            templateUrl: 'Scripts/app/HTMLPages/about.html',
            controller: 'aboutController'
        })

        // route for the contact page
        .when('/contact', {
            templateUrl: 'Scripts/app/HTMLPages/contact.html',
            controller: 'contactController'
        })

        .when('/VacancyTabel', {
            templateUrl: 'Scripts/app/HTMLPages/VacancyTabel.html',
            controller: 'safeCtrl'
        })

        .otherwise({
            redirectTo: '/'
        });
});

// create the controller and inject Angular's $scope
MyApp.controller('mainController', function ($scope) {
    // create a message to display in our view
    $scope.message = 'Everyone come and see how good I look!';
});

MyApp.controller('aboutController', function ($scope) {
    $scope.message = 'Look! I am an about page.';
});

MyApp.controller('contactController', function ($scope) {
    $scope.message = 'Contact us! JK. This is just a demo.';
});

MyApp.controller('safeCtrl', ['$scope', '$http', '$timeout', '$interval', function ($scope, $http, $timeout, $interval) {

    var DataToAlert;

    pollData();

    function pollData() {
        
        var collection = [];

        $interval(function () {

            $http.get("/Home/GetVacancyList").then(function (result) {

                angular.forEach(result.data, function (item, key) {
                    console.log("DataKey: " + key + " DataValue: " + item);
                    console.log("DataKey: " + key + "Company: " + item.Company);

                    var row = { Title: item.Title, Company: item.Company, Salary: item.Salary }

                    console.log("Row: " + row + " Row -> Title: " + row.Title +  " Row -> Company: " + row.Company + " Row -> Salary: " + row.Salary);
                    collection.push(row);
                });

                $scope.rowCollection = collection;
            });

        }, 20000);
    }
}]);
 

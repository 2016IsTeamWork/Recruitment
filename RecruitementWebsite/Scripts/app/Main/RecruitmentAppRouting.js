
var MyApp = angular.module('MyApp');

// configure our routes

MyApp.config(function ($routeProvider, $locationProvider) {
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

        .when('/VacancyTemplate/:id', {
            templateUrl: 'Scripts/app/HTMLPages/VacancyTemplate.html',
            controller: 'VacancyTemplateController'
        })

        .otherwise({
            redirectTo: '/'
        });
    //$locationProvider.html5Mode(true);
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

MyApp.controller('VacancyTemplateController', function ($scope, $http, $routeParams) {

    var data = null;
    console.log("Feel the power of manifestation while you're tired: " + $scope.OurOwnCollection);
    $scope.ScopeItem = $scope.OurOwnCollection[1];
    console.log("Print one item of the collection: " + " Scope ID: " + ScopeItem.ID + " Scope Title: " + ScopeItem.Title);
});

MyApp.factory('SharedVacancyDataService', function () {

    var savedData = {}
    function set(data) {
        console.log("Data set in SharedVacancyDataService: " + data);
        savedData = data;
    }
    function get() {
        if (savedData == null){
            return "This is empty!";
        }
        else {
            return savedData;
        }
    }

    return {
        set: set,
        get: get
    }

});

MyApp.controller('safeCtrl', ['$scope', '$http', '$timeout', '$interval', function ($scope, $http, $timeout, $interval) {

    FillTable();

    function FillTable() {

        var collection = [];

            $http.get("/Home/GetVacancyList").then(function (result) {

                angular.forEach(result.data, function (item, key) {

                    var row = { TableID: key, ID: item.ID, Title: item.Title, City: item.City, Salary: item.Salary, Description: item.Description}

                    collection.push(row);
                });

                $scope.OurOwnCollection = collection;
             
                $scope.rowCollection = collection;

            });
    }
}]);




 

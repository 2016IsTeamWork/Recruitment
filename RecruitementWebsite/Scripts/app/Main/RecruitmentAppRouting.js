
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


    //Setting background image

    //$scope.backgroundImg = 'url(http://www.thespiritofamsterdam.com/wp-content/uploads/2012/02/22630115_s-2-300x300.jpg)';
    //    $scope.heroImage = {
    //        background: $scope.backgroundImg
    //    };

    //    console.log($scope.heroImage);
   
  //Setting carousel info

    //$scope.myInterval = 5000;
    //$scope.noWrapSlides = false;
    //$scope.active = 0;
    //var slides = $scope.slides = [];
    //var currIndex = 0;

    //$scope.addSlide = function () {
    //    var newWidth = 600 + slides.length + 1;
    //    slides.push({
    //        image: 'http://cdn1.tnwcdn.com/wp-content/blogs.dir/1/files/2016/02/shutterstock_199317665.jpg',
    //        text: "What we offer: " + slides.length
    //    });
    //};

    //$scope.randomize = function () {
    //    var indexes = generateIndexesArray();
    //    assignNewIndexesToSlides(indexes);
    //};

    //for (var i = 0; i < 4; i++) {
    //    $scope.addSlide();
    //}

    //// Randomize logic below

    //function assignNewIndexesToSlides(indexes) {
    //    for (var i = 0, l = slides.length; i < l; i++) {
    //        slides[i].id = indexes.pop();
    //    }
    //}

    //function generateIndexesArray() {
    //    var indexes = [];
    //    for (var i = 0; i < currIndex; ++i) {
    //        indexes[i] = i;
    //    }
    //    return shuffle(indexes);
    //}

    //// http://stackoverflow.com/questions/962802#962890
    //function shuffle(array) {
    //    var tmp, current, top = array.length;

    //    if (top) {
    //        while (--top) {
    //            current = Math.floor(Math.random() * (top + 1));
    //            tmp = array[current];
    //            array[current] = array[top];
    //            array[top] = tmp;
    //        }
    //    }

    //    return array;
    //}
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

MyApp.controller('safeCtrl', ['$scope', '$http', '$timeout', '$interval', function ($scope, $http, $timeout, $interval, SharedVacancyDataService) {

    SharedVacancyDataService.get();

    var DataToAlert;

    pollData();

    function pollData() {
        
        var collection = [];

        $interval(function () {

            $http.get("/Home/GetVacancyList").then(function (result) {

                angular.forEach(result.data, function (item, key) {
                    console.log("DataKey: " + key + " DataValue: " + item);
                    console.log("DataKey: " + key + "Company: " + item.Company);

                    var row = { ID: key, Title: item.Title, Company: item.Company, Salary: item.Salary }

                   // console.log("Row: " + row + " Row -> Title: " + row.Title +  " Row -> Company: " + row.Company + " Row -> Salary: " + row.Salary);
                    collection.push(row);
                });

                $scope.OurOwnCollection = collection;
               // console.log("The collection that is on the Scope right now: " + $scope.OurOwnCollection);
                $scope.rowCollection = collection;

                SharedVacancyDataService.set(collection);
            });

        }, 20000);
    }
}]);




 

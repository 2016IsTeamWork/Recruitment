
MyApp.controller('contactController', ['$scope', '$http', function ($scope, $http) {

    $scope.result = 'hidden';
    $scope.resultMessage = 'message';
    $scope.contactData = '';
    $scope.submitButtonDisabled = false;
    $scope.submitted = false;
    $scope.submit = function (contactform) {
        console.log(contactform);
        $scope.submitted = true;
        $scope.submitButtonDisabled = true;

        if (contactform.$valid) {
            $http({
                method: 'POST',
                url: '',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).succes(function (data) {
                if (data.succes) {
                    $scope.submitButtonDisabled = true;
                    $scope.resultMessage = data.message;
                    $scope.result = 'bg-succes';
                }
                else {
                    $scope.submitButtonDisabled = false;
                    $scope.resultMessage = data.message;
                    $scope.result = 'bg-danger';

                }
            });
        }
        else {
            $scope.submitButtonDisabled = false;
            $scope.resultMessage = "Failed to submit";
            $scope.result = 'bg-danger';
        }
    }
}]);

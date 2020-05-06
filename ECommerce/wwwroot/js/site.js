// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const app = angular.module('mainApp', []);

app.service('apiService', ['$http', function ($http) {
    this.getProductList = (succeedCallback, failedCallback) => {
        $http.get('/product/listdata?p=1&index=0').then((response) => {
            // console.log(response);
            if (!response) {
                if (failedCallback) {
                    failedCallback({
                        isNullResponse: true
                    });
                }
            } else if (succeedCallback) {
                succeedCallback(response.data);
            }
        });
    };
}]);

app.controller('homeController', ['$scope', '$http', 'apiService', function ($scope, $http, apiService) {
    var self = this;
    self.productList = [];

    var bindData = function (response) {
        // console.log(response);
        if (response.success && response.data) {
            // set data to object
            self.productList = response.data;
        }
    }

    $scope.init = (params) => {
        
        // TODO
        // Load data from server side
        apiService.getProductList(bindData);

    };
}]);
(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',
        'ui.select',
        'ui.router',
        'ui.bootstrap',
        'ui.jq',
        'akFileUploader',
        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function ($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/vehicles');
            $stateProvider
                .state('vehicles', {
                    url: '/vehicles',
                    templateUrl: '/App/Main/views/vehicles/vehicles.cshtml',
                    menu: 'Vehicles' //Matches to name of 'NewTask' menu in SimpleTaskSystemNavigationProvider
                }).state('viewVehicle', {
                    url: '/viewVehicle/:id',
                    templateUrl: '/App/Main/views/vehicles/viewVehicle.html',
                    controller: 'viewVehicleCtrl',
                    controllerAs:'vm'
                    //menu: 'Vehicles' //Matches to name of 'NewTask' menu in SimpleTaskSystemNavigationProvider
                });
        }
    ]);

    app.factory("entityService",
        ["akFileUploaderService", function (akFileUploaderService) {
            var saveTutorial = function (tutorial) {
                return akFileUploaderService.saveModel(tutorial, "/Home/saveTutorial");
            };
            return {
                saveTutorial: saveTutorial
            };
        }])

})();
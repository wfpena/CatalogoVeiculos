(function () {
    angular.module('app').controller('viewVehicleCtrl', [
        '$stateParams','$http', '$scope', 'abp.services.tasksystem.vehicle', "entityService",
        function ( $stateParams,$http, $scope,  vehicleService, entityService) {
            var vm = this;
            vm.images = [];
            //console.log($routeParams.id);

            var id = $stateParams.id;

            getVehicle(id);

            function getVehicle(id) {
                abp.ui.setBusy(null,
                    vehicleService.getVehicle(id)
                        .then(function (data) {
                            vm.vehicle = data.data;
                            
                        })
                )
            };
        }
    ]);
})();
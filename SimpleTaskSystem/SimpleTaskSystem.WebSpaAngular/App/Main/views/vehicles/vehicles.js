(function() {
    var app = angular.module('app');

    var controllerId = 'VehicleCtrl';
    app.controller(controllerId, [
        '$http','$scope','$uibModal' , 'abp.services.tasksystem.vehicle',
        function ($http, $scope,$uibModal ,vehicleService) {
            var vm = this;
            
            vm.localize = abp.localization.getSource('SimpleTaskSystem');

            //vm.vehicles = [];

            getList();

            vm.openVehicleCreationModal = function () {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/vehicles/newVehicleModal.html',
                    controller: 'newVehicleCtrl as vm',
                    backdrop: 'static'
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getList();
                });
            };

            vm.openVehicleEditModal = function (vehicle) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/vehicles/editVehicleModal.html',
                    controller: 'editVehicleCtrl as vm',
                    backdrop: 'static',
                    resolve: {
                        id: function () {
                            return vehicle.id;
                        }
                    }
                });

                modalInstance.rendered.then(function () {
                    $.AdminBSB.input.activate();
                });

                modalInstance.result.then(function () {
                    getList();
                });
            };

            vm.deleteVehicle = function (data) {
                abp.ui.setBusy(null,
                vehicleService.deleteVehicle(data.id)
                    .then(function () {
                        $http.get('/Home/deleteFiles', { params: {myTest: data.imagens}}).then(function (data) {
                            if (data !== null && data.data == "success") {
                                abp.notify.info("Veículo excluído com sucesso");
                                getList();
                            }
                        }, function (error) {
                            //Handle Error 
                        });
                    }))
            };

            vm.deleteAll = function () {
                vehicleService.deleteAll()
                    .then(function () {
                        abp.notify.info("Título excluído com sucesso");
                        getList();
                    })
            };

            function getList() {
                abp.ui.setBusy(null,
                      vehicleService.getAll()
                          .then(function (data) {
                              vm.vehicles = data.data;
                          })
                )
            };

            
            vm.insertVehicle = function () {
                //abp.ui.setBusy(
                var newTitle = "Título " + (vm.totalMainVehicles + 1);
                vehicleService.createVehicle({ title: newTitle , description: "Descrição para " + newTitle },0)
                    .then(function () {
                        abp.notify.info("Título inserido com sucesso");
                        getList();
                    })
                //);
            };            

            vm.updateVehicle = function (vehicle) {
                vehicleService.updateVehicle(vehicle).then(function () {
                    abp.notify.info("Título modificado com sucesso");
                    getList();
                })
            };
        }
    ]);
})();
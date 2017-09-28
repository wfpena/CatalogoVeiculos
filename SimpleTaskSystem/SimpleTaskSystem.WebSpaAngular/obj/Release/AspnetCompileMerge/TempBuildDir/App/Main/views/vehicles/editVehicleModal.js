(function () {
    angular.module('app').controller('editVehicleCtrl', [
        '$http', '$scope', '$uibModalInstance', 'abp.services.tasksystem.vehicle', "entityService", 'id',
        function ($http, $scope, $uibModalInstance, vehicleService, entityService, id) {
            var vm = this;
            vm.images = [];
            vm.imagesToRemove = [];

            getVehicle(id);

            function getVehicle(id) {
                abp.ui.setBusy(null,
                    vehicleService.getVehicle(id)
                        .then(function (data) {
                            vm.vehicle = data.data;
                            vm.images = data.data.imagens;
                        })
                )
            };

            vm.removeImage = function (image, index) {
                vm.images.splice(index, 1);
                vm.imagesToRemove.push(image);
                //var config = {
                //    params: { myTest: image }
                //}

                //$http.get('/Home/deleteFileFromFolder', config).then(function (data) {
                //    if (data !== null && data.data == image) {
                //        vm.images.splice(index, 1);
                //    }
                //}, function (error) {
                //    //Handle Error 
                //});
            }

            vm.save = function () {
                $http.get('/Home/deleteFiles', { params: { myTest: vm.imagesToRemove } }).then(function (data) {
                    if (data !== null && data.data == "success") {
                        //abp.notify.info("Veículo excluído com sucesso");
                        //getList();
                    }
                }, function (error) {
                    //Handle Error 
                });

                vm.vehicle.imagens = vm.images;
                abp.ui.setBusy(null,
                    vehicleService.updateVehicle(vm.vehicle)
                        .then(function () {
                            abp.notify.info("Veiculo Cadastrado");
                            $uibModalInstance.close();
                        })
                )
            };

            vm.saveTutorial = function (tutorial) {
                abp.ui.setBusy(null,
                entityService.saveTutorial(tutorial)
                    .then(function (data) {
                        vm.images.push(data.data);
                        })
                )
            };

            function getTypes() {
                abp.ui.setBusy(null,
                    vehicleService.getTypes()
                        .then(function (data) {
                            vm.types = data.data;
                        })
                )
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            getTypes();
        }
    ]);
})();
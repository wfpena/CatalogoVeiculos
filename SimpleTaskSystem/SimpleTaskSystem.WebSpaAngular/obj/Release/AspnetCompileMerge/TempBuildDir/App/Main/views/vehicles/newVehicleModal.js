(function () {
    angular.module('app').controller('newVehicleCtrl', [
        '$http', '$scope', '$uibModalInstance', 'abp.services.tasksystem.vehicle', "entityService",
        function ($http, $scope, $uibModalInstance, vehicleService, entityService) {
            var vm = this;
            vm.images = [];

            vm.removeImage = function (image,index) {
                var config = {
                    params: { myTest: image }
                }

                $http.get('/Home/deleteFileFromFolder', config).then(function (data) {
                    if (data !== null && data.data == image) {
                        vm.images.splice(index, 1);
                    }
                }, function (error) {
                    //Handle Error 
                });
            }

            vm.save = function () {
                vm.vehicle.imagens = vm.images;
                abp.ui.setBusy(null,
                    vehicleService.createVehicle(vm.vehicle)
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
                var config = {
                    params: { myTest: vm.images }
                }
                $http.get('/Home/deleteFiles', config).then(function (data) {
                    //if (data !== null && data.data == image) {
                    //    vm.images.splice(index, 1);
                    //}
                }, function (error) {
                    //Handle Error 
                });

                $uibModalInstance.dismiss({});
            };

            getTypes();
        }
    ]);
})();
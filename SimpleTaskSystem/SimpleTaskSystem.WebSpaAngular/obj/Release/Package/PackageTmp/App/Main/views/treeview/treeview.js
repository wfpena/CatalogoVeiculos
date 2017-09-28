(function() {
    var app = angular.module('app');

    var controllerId = 'TreeCtrl';
    app.controller(controllerId, [
        '$scope', 'abp.services.tasksystem.node',
        function($scope, nodeService) {
            var vm = this;
            
            vm.localize = abp.localization.getSource('SimpleTaskSystem');

            vm.nodes = [];

            getList();

            vm.deleteNode = function (data) {
                nodeService.deleteNodes(data.id)
                    .success(function () {
                        abp.notify.info("Título excluído com sucesso");
                        getList();
                    })
            };

            vm.deleteAll = function () {
                nodeService.deleteAll()
                    .success(function () {
                        abp.notify.info("Título excluído com sucesso");
                        getList();
                    })
            };

            function getList() {
                abp.ui.setBusy(null,
                      nodeService.getAll()
                          .success(function (data) {
                              vm.nodes = data;
                              vm.totalMainNodes = data.length;
                              angular.forEach(vm.nodes, function (value, key) {
                                  value.editing = false;
                              });
                          })
                )
            };

            vm.editItem = function (item) {
                item.editing = true;
            }

            vm.doneEditing = function (item) {
                item.editing = false;
                nodeService.updateNode({id: item.id, title: item.title, description: item.description }).success(function () {
                    abp.notify.info("Nome modificado com sucesso");
                    getList();
                })
            };
            
            vm.insertNode = function () {
                //abp.ui.setBusy(
                var newTitle = "Título " + (vm.totalMainNodes + 1);
                nodeService.createNode({ title: newTitle , description: "Descrição para " + newTitle },0)
                    .success(function () {
                        abp.notify.info("Título inserido com sucesso");
                        getList();
                    })
                //);
            };

            vm.insertChildNode = function (node) {
                //abp.ui.setBusy(
                var newTitle = node.title + "." + node.childNodes.length;
                nodeService.createNode({ title: newTitle, description: newTitle + " - Descrição" }, node.id)
                    .success(function () {
                        abp.notify.info("Subtítulo inserido com sucesso");
                        getList();
                    })
                //);
            };

            vm.updateNode = function (node) {
                nodeService.updateNode(node).success(function () {
                    abp.notify.info("Título modificado com sucesso");
                    getList();
                })
            };

            vm.payClick = function (node) {
                nodeService.payClick().success(function () {
                    //abp.notify.info("Título modificado com sucesso");
                    //getList();
                })
            };
        }
    ]);
})();
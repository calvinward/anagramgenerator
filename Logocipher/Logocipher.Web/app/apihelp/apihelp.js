(function () {
    'use strict';

    angular.module('app.apihelp', ['ngRoute'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/apihelp', {
            templateUrl: 'app/apihelp/apihelp.html',
            controller: 'ApiHelpCtrl',
            controllerAs: 'vm'
        });
    }])

    .controller('ApiHelpCtrl', ApiHelp);

    function ApiHelp() {
        var vm = this;
        vm.title = 'Api';
    }

})();
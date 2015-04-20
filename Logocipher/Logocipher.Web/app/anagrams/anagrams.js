(function () {
    'use strict';

    angular.module('app.anagrams', ['ngRoute'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/anagrams', {
            templateUrl: 'app/anagrams/anagrams.html',
            controller: 'AnagramsCtrl',
            controllerAs: 'vm'
        });
    }])

    .controller('AnagramsCtrl', ['dataservice', function (dataservice) {
        var vm = this;
        vm.title = 'Anagrams';
        vm.word = '';
        vm.anagrams = [];
        vm.showEmptyMessage = false;
        vm.showInstructions = !vm.word.length;

        vm.submit = function () {
            vm.anagrams = [];
            vm.showInstructions = false;
            dataservice.getAnagrams(vm.word).then(function (data) {
                if (data.length) {
                    vm.anagrams = data;
                    vm.showEmptyMessage = false;
                } else {
                    vm.showEmptyMessage = true;
                }
            });
        }

    }]);

})();
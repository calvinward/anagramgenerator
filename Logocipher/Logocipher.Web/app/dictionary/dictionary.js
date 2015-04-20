(function () {
    'use strict';

    angular.module('app.dictionary', ['ngRoute'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/dictionary', {
            templateUrl: 'app/dictionary/dictionary.html',
            controller: 'DictionaryCtrl',
            controllerAs: 'vm'
        });
    }])

    .controller('DictionaryCtrl', ['dataservice', function (dataservice) {
        var vm = this;
        vm.title = 'Dictionary';
        vm.letters = [];
        vm.words = [];

        dataservice.getLetters().then(function (data) {
            vm.letters = data;
        });

        vm.seeWords = function (letter) {
            vm.words = [];
            dataservice.getWords(letter).then(function (data) {
                vm.words = data;
            });
        }

    }]);

})();
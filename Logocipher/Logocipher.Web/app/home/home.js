(function () {
    'use strict';

    angular.module('app.home', ['ngRoute'])

    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/home', {
            templateUrl: 'app/home/home.html',
            controller: 'HomeCtrl',
            controllerAs: 'vm'
        });
    }])

    .controller('HomeCtrl', Home);

    function Home() {
        var vm = this;
        vm.title = 'Welcome!';
    }

})();
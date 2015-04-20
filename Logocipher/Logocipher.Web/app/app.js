(function () {
    'use strict';

    angular.module('app', [
      'ngRoute',
      'app.home',
      'app.anagrams',
      'app.dictionary',
      'app.apihelp'
    ]).
    config(['$routeProvider', function ($routeProvider) {
        $routeProvider.otherwise({ redirectTo: '/home' });
    }]);

})();
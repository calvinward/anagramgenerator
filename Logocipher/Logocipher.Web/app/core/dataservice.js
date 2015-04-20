(function () {
    'use strict';

    angular.module('app')
        .factory('dataservice', dataservice);

    function dataservice($http) {

        var service = {
            getAnagrams: getAnagrams,
            getLetters: getLetters,
            getWords: getWords
        };

        return service;

        function getAnagrams(text) {
            $.blockUI({ message: '<h1>Grabbing your anagrams, just a second...</h1>' });

            return $http.get('/api/anagrams?text=' + text)
                .then(getAnagramsComplete)
                .catch(function (result) {
                    if (result.data.ExceptionMessage) {
                        alert(result.data.ExceptionMessage);
                    } else {
                        alert(result);
                    }
                }).finally(function () {
                    $.unblockUI();
                });

            function getAnagramsComplete(result) {
                return result.data;
            }
        }


        function getLetters() {
            return $http.get('/api/letters')
                .then(getLettersComplete)
                .catch(function (result) {
                    if (result.data.ExceptionMessage) {
                        alert(result.data.ExceptionMessage);
                    } else {
                        alert(result);
                    }
                }).finally(function () {

                });

            function getLettersComplete(result) {
                return result.data;
            }
        }


        function getWords(letter) {
            $.blockUI({ message: '<h1>Grabbing your words, just a second...</h1>' });
            return $http.get('/api/words?letter=' + letter)
                .then(getWordsComplete)
                .catch(function (result) {
                    if (result.data.ExceptionMessage) {
                        alert(result.data.ExceptionMessage);
                    } else {
                        alert(result);
                    }
                }).finally(function () {
                    $.unblockUI();
                });

            function getWordsComplete(result) {
                return result.data;
            }
        }

    }
})();
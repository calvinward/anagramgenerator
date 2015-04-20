##Logocipher 

Logocipher, the name, is a weak portmanteau (or amalgam) of Logos (word) and Cipher (puzzle). Logocipher allows the generation of anagrams from words and phrases.

###Approach

Initially the solution started with breaking apart the word that was supplied by the user into all of its various possible combinations of characters that could make up one or more phrases. 

At 6 characters, that approach was starting to be questionable in performance and at 7 characters the performance became unbearably slow.

In the current revision, Logocipher comes at this from the opposite direction, by reducing the number of words to compare against out of the starting dictionary of ~300k words by filtering out words that are too long, words that don't contain only letters that are part of the user supplied word, and so forth. Then Logocipher takes that subset of possible words and combines them in all possible combinations to compare against the supplied word.

This has resulted in much stronger performance of larger words than was possible from the other direction. For 'octopus', there are only ~200 possible words to recombine in the source dictionary.

Judicious use of some parallel functionality helped slightly for both loading of the dictionary and anagram generation. While better, the speed of the retrieval on words larger than 12 or so characters can still use some improvement.

###Built with:
* Visual Studio 2013 Update 4 because .NET
* ASP.NET Web API for RESTfulness
* Ninject for server side IOC
* Bower for client side package management
* Gulp for moving 3rd party client assets into the solution
* AngularJS for client side SPAness
* Bootstrap for UI goodness

###To Run
* Restore Nuget packages (usually with a build)
* Restore Bower packages (usually with `bower install`)
* Restore NPM packages (usually with `npm install`)

###TODO
* Improve performance of Anagram lookup
* Evaluate storage of word dictionary, may impact the previous item
* Improve code organization to better support unit testing and add unit tests
* Add build, watch, & test gulp tasks for client side assets
* Improve error handling and feedback mechanisms
* Evaluate browser support (this was only tested on Chrome)
* Pull the content for the home page directly from the readme markdown file
* Other cleanup items, such as better relative URLs, placement of 'page' titles, etc.
* Link generated anagrams with the definition of the words in the anagram
* Implement a cache buster
* Improve mobile friendliness

###Additional Notes
* There's a small console app to do basic testing without having to fire up the rest of the stack
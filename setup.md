Setup
=====

* To run Windows programs on a Mac, we need to install the `mono` library using Homebrew:
    ```
    $ brew install mono
    ```

* Install the nuget library, which is a package manager for .NET:
    ```
    $ brew install nuget
    ```

* Next, we need to install all of this project's dependencies:
    ```
    $ nuget restore
    ```

* Finally, we need to compile and build the project using Microsoft Build Engine:
    ```
    $ msbuild
    ```
    

* To run the set of scripts to setup and run tests for GPConnect, run the following commands:
    ```
    $ cd scripts && npm install
    $ TEST_USERNAME=#{username} PASS=#{password} node index.js
    ```
    Please note that the username and password need to be replaced above when run.


* To run all acceptance tests, use the following command:
    ```
    $ auth="#{authorisation_code}" sh build_and_test.sh localhost 8080 "cat=opengp"
    ```
    Please note that the authorisation_code needs to be replaced above when run.


* To run all acceptance tests in a specific file, use the following command:
    ```                                                                           
    $ auth="#{authorisation_code}" sh build_and_test.sh localhost 8080 "Description=#{FeatureFileName}"
    ```
    Please note that the authorisation_code and FeatureFileName need to be replaced above when run.
 
 
* To only run specific acceptance tests, add the @Focus annotation to each test that you want to run, then run the following command:
    ```                                                                       
    $ auth="#{authorisation_code}" sh build_and_test.sh localhost 8080 "cat=Focus"
    ```
    Please note that the authorisation_code needs to be replaced above when run.


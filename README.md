# webAPITemplate
Template for Asp.net core 2.1 web api with best practices.

## prerequisite
#### VS 2017
#### asp.net core 2.1

## features
#### JWT token authantication (authantication server and resource server)
#### Swagger documentation 
#### Nlog logging provider integration (adapatable for any other logging provider easily)
#### all exceptions handled in one palce, it return internal server error and log the whole exception in to error log 
#### separate configs between production and development 

## testing
#### get api/test  can call Anonymously  and it will return "test:" + config value in test (test configuration and the build)
#### token will grant through token endpoint (post /api/token) when all parameters are set to "test" (client id, cleint secret, audience)
#### use above token to call api/test/[int]  , it will retun "value:" [int]  (use to test the authantication)

## publish
#### web deploye will work for IIS, once the core module is isntalled. test

# MSMQ Health Check

This is a commandline tool under Windows platform to test MSMQ's health.

## How to use


#### Options

* pathName
* formatName
* logLevel

```
> MSMQHealthCheck.exe --pathName ".\private$\default"
```

```
> MSMQHealthCheck.exe --pathName ".\private$\default" --logLevel Debug
```

```
> MSMQHealthCheck.exe --formatName "DIRECT=TCP:192.168.19.133\private$\default"
```

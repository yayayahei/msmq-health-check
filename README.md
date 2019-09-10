﻿# MSMQ Health Check

This is a commandline tool under Windows platform to test MSMQ's health.

## How to use


#### Options
* help
```
> MSMQHealthCheck.exe --help
> MSMQHealthCheck.exe -h
> MSMQHealthCheck.exe /h
```
* pathName
```
> MSMQHealthCheck.exe --pathName ".\private$\default"
```
* formatName
```
> MSMQHealthCheck.exe --formatName "DIRECT=TCP:192.168.19.133\private$\default"
```
* logLevel
```
> MSMQHealthCheck.exe --pathName ".\private$\default" --logLevel Debug
```
* sendHello
```
> MSMQHealthCheck.exe --formatName "DIRECT=TCP:192.168.19.133\private$\default" --sendHello
```
* getMessage
```
> MSMQHealthCheck.exe --formatName "DIRECT=TCP:192.168.19.133\private$\default" --getMessage
```









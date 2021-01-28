LogManager Library by choipureum v1
=============

This library is the **first step** of a Library Projects. 
Please visit my blog 
https://blue-boy.tistory.com/

-----------

Installation
-----------

```c#
bundle install
BabyCarrot.Tools
```
```c#
GitHub:: https://github.com/choipureum/LogManager
```
from this directory.

Usage
-----

Basic form:

```c#
 c#
.Net core Framework

```


And method form:

```c#
LogManager() : Daily Log || Monthly Log
LogManager() : add prefix || postfix + yyyyMMdd .txt
Write()
WriteLine()

```
사용형식 

```c#
 public LogManager(string path, LogType logType, string prefix, string postfix)
 public LogManager(string prefix, string postfix)
 public LogManager()
            : this(Path.Combine(Application.Root, "Log"), LogType.Daily, null, null)
 private void _SetLogPath(LogType logType, string prefix, string postfix)            
```


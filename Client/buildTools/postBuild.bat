@echo off

set outDirClient=..\output\client\

rd /s /q %outDirClient%
md %outDirClient%
xcopy .output\* %outDirClient% /s /y /EXCLUDE:exclude.cfg
xcopy webview\* %outDirClient%webview\* /s /y /EXCLUDE:exclude.cfg
xcopy resource.cfg %outDirClient% /s /y /EXCLUDE:exclude.cfg
xcopy index.mjs %outDirClient% /s /y /EXCLUDE:exclude.cfg
rd /s /q xcopy .output\
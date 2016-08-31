#!/bin/bash

rm -f Parser_Generated/*
java -Xmx500M -cp "antlr-4.5.1-complete.jar:$CLASSPATH" org.antlr.v4.Tool -Dlanguage=CSharp -visitor -o Parser_Generated Asm.g4

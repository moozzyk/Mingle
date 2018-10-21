cmake_minimum_required (VERSION 2.8.11)
project (duktape)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} --std=c99 -fPIC")

set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${PROJECT_BINARY_DIR}/bin)
set (SOURCES
build/duktape/duktape.c)

add_library (duktape SHARED ${SOURCES})

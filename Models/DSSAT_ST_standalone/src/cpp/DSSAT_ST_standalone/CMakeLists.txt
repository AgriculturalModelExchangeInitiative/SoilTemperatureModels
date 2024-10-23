cmake_minimum_required(VERSION 3.12)
project(DSSAT_ST_standalone)

message(STATUS "-> DSSAT_ST_standalone")

# https://cmake.org/cmake/help/latest/prop_tgt/CXX_STANDARD.html
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)

set(MT_RUNTIME_LIB 1)

#set absolute filenames (to resolve .. in paths)
macro(set_absolute_path var_name path)
	get_filename_component(toAbsPath ${path} ABSOLUTE)
	set(${var_name} ${toAbsPath})
endmacro(set_absolute_path)

#define delete file from path
macro(remove_file list_name file_name)
	get_filename_component(toAbsPath ${file_name} ABSOLUTE)
	list(REMOVE_ITEM ${list_name} "${toAbsPath}")
endmacro(remove_file)

#define source_groups 
macro(GroupSources curdir baseDir)
   file(GLOB children RELATIVE ${baseDir}/${curdir} ${baseDir}/${curdir}/*)
   foreach(child ${children})
		  if(IS_DIRECTORY ${baseDir}/${curdir}/${child})
				  GroupSources(${curdir}/${child} ${baseDir})
		  else()
				string(REPLACE "/" "\\" groupname ${curdir})
			source_group(${groupname} FILES ${baseDir}/${curdir}/${child})
		  endif()
   endforeach()
endmacro()

if(MSVC)
	# disable security warnings in windows
	add_definitions(-D_CRT_SECURE_NO_WARNINGS)
	
	# define MS Visual Studio toolset version
	if(NOT DEFINED MSVC_TOOLSET_VERSION)
		if(MSVC_VERSION GREATER_EQUAL 1930)
		  set(MSVC_TOOLSET_VERSION "") # leave unknown for future versions
		elseif(MSVC_VERSION GREATER_EQUAL 1920)
		  set(MSVC_TOOLSET_VERSION 142) # VS 2019
		elseif(MSVC_VERSION GREATER_Echannel_mainQUAL 1910)
		  set(MSVC_TOOLSET_VERSION 141) # VS 2017
		elseif(MSVC_VERSION EQUAL 1900)
		  set(MSVC_TOOLSET_VERSION 14) # VS 2015
		else()
		 # we do not support older version
		endif()
	endif()
endif()

# setup the target group variable, used to group targets into folders in IDEs
set_property(GLOBAL PROPERTY USE_FOLDERS ON)

message(STATUS "cmake_generator = ${CMAKE_GENERATOR}")
message(STATUS "size_of_void =  ${CMAKE_SIZEOF_VOID_P}")
if(${CMAKE_SIZEOF_VOID_P} STREQUAL "4")
    set(ARCH "x86")
elseif(${CMAKE_SIZEOF_VOID_P} STREQUAL "8")
    set(ARCH "x64")
endif()

find_package(Threads REQUIRED)

#------------------------------------------------------------------------------

# create DSSAT_ST_standalone_lib
add_library(DSSAT_ST_standalone_lib
	STEMP.h
	STEMP.cpp
	STEMP_Auxiliary.h
	STEMP_Auxiliary.cpp
	STEMP_Component.h
	STEMP_Component.cpp
	STEMP_Exogenous.h
	STEMP_Exogenous.cpp
	STEMP_Rate.h
	STEMP_Rate.cpp
	STEMP_State.h
	STEMP_State.cpp
)
target_link_libraries(DSSAT_ST_standalone_lib
	PUBLIC
	${CMAKE_THREAD_LIBS_INIT}
	${CMAKE_DL_LIBS}
)
target_include_directories(DSSAT_ST_standalone_lib
	PUBLIC
	${CMAKE_CURRENT_SOURCE_DIR}     # for #include "STEMP_Component.h"
	${CMAKE_CURRENT_SOURCE_DIR}/..  # for #include "DSSAT_ST_standalone/STEMP_Component.h"
)
if (MSVC)
	target_compile_options(DSSAT_ST_standalone_lib PRIVATE "/MT$<$<CONFIG:Debug>:d>")
endif()

#------------------------------------------------------------------------------

message(STATUS "<- DSSAT_ST_standalone")
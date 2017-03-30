LIBS=-r:MonoGame.Framework.dll
TARGET=-target:winexe -out:bin/Program.exe

#CONTENT:=$(wildcard Content/*.*)

OS:=$(shell uname)

ifeq ($(OS),Linux)
MONOGAME=/usr/lib/mono/xbuild/MonoGame/v3.0/Assemblies/DesktopGL
endif

ifeq ($(OS),Darwin)
MONOGAME=/Library/Frameworks/MonoGame.framework/Current/Assemblies/DesktopGL
endif

LIBPATHS=-lib:$(MONOGAME)

all: compile

#.PHONY: clean
clean:
	rm -rf bin

compile: copy_libs
	mkdir -p bin
	mcs $(LIBPATHS) $(LIBS) $(TARGET) -recurse:src/*.cs

#content: Content/US_Canyon.png
#	echo $(CONTENT)
#	echo /compress               > Content.mgcb
#	echo /intermediateDir:obj   >> Content.mgcb
#	echo /outputDir:bin/Content >> Content.mgcb
#	echo /quiet                 >> Content.mgcb
#
#	for fn in Content/*; do \
#		make $$fn;      \
#	done
#	rm Content.mgcb

copy_libs:
	mkdir -p bin
	cp -nr $(MONOGAME)/* bin

run: compile
	cd bin; \
	mono Program.exe

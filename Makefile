#---------------------------------------
# CONSTANTS
#---------------------------------------

BINDIR=bin
COMPILER=mcs
FLAGS=-target:winexe
LIBPATHS=-lib:$(MONOGAME)
LIBS=MonoGame.Framework.dll
OBJDIR=obj
SRCDIR=src
TARGET=Program.exe

CONTENT:=$(wildcard Content/*)
CONTENTFILE=content.mgcb

#---------------------------------------
# INITIALIZATION
#---------------------------------------

# Linux and macOS have different paths to the MonoGame library files, so make
# sure to set them up properly. No Windows support here, lol!

OS:=$(shell uname)

ifeq ($(OS),Linux)
MONOGAME=/usr/lib/mono/xbuild/MonoGame/v3.0/Assemblies/DesktopGL
endif

ifeq ($(OS),Darwin)
MONOGAME=/Library/Frameworks/MonoGame.framework/Current/Assemblies/DesktopGL
endif

#---------------------------------------
# TARGETS
#---------------------------------------

# Always recompile. Makes it easier to work on the project.
.PHONY: $(BINDIR)/$(TARGET)

# Don't check for existing files when making the following targets.
.PHONY: all clean libs run

# Default target.
all: $(BINDIR)/$(TARGET) content libs

clean:
	rm -rf $(CONTENTFILE) $(BINDIR) $(OBJDIR)

$(BINDIR)/$(TARGET):
	mkdir -p $(BINDIR)
	$(COMPILER) $(FLAGS)		     \
	            $(LIBPATHS)		     \
	            $(addprefix -r:,$(LIBS)) \
	            -out:$(BINDIR)/$(TARGET) \
	            -recurse:$(SRCDIR)/*.cs

libs:
	mkdir -p $(BINDIR)
	cp -nr $(MONOGAME)/* $(BINDIR)

run: all
	cd $(BINDIR); \
	mono $(TARGET)

#-------------------
# MONOGAME
#-------------------

# Kind of a hack to build content easily.
.PHONY: Content/*

Content/*.fbx:
	@echo /build:$@ >> $(CONTENTFILE)

Content/*.png:
	@echo /build:$@ >> $(CONTENTFILE)

pre-content:
	@echo /compress                   > $(CONTENTFILE)
	@echo /intermediateDir:$(OBJDIR) >> $(CONTENTFILE)
	@echo /outputDir:$(BINDIR)       >> $(CONTENTFILE)
	@echo /quiet                     >> $(CONTENTFILE)

content: pre-content $(CONTENT)
	mkdir -p $(BINDIR)
	mgcb -@:$(CONTENTFILE)
	rm $(CONTENTFILE)

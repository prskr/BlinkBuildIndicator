#!/bin/sh
set -e

docfx ./docs/docfx.json

SOURCE_DIR=$PWD
TEMP_DOC_DIR=$PWD/../doc-temp

echo "Removing temporary doc directory $TEMP_REPO_DIR"
rm -rf $TEMP_DOC_DIR
mkdir $TEMP_DOC_DIR

echo "Copy documentation into temp directory"
cp -r $SOURCE_DIR/docs/_site/* $TEMP_DOC_DIR

echo "Switching to gh-pages branch"
git checkout gh-pages

echo "Clear repo directory"
#git rm -r *

echo "Copy documentation into the repo"
#cp -r $TEMP_REPO_DIR .

echo "Push the new docs to the remote branch"
#git add . -A
#git commit -m "Update generated documentation"
#git push origin gh-pages
#git checkout master
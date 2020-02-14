let gulp = require("gulp");
let browserify = require("browserify");
let tsify = require("tsify");
let source = require("vinyl-source-stream");
let buffer = require("vinyl-buffer");
let sourcemaps = require("gulp-sourcemaps");



gulp.task("default", function (done) {
    console.log("gulp is working!");
    done();
});

gulp.task("compile-ts", function (done) {
    let bundler = browserify({
        basedir: ".",
        debug: true,
        entries: [
            "ClientApp/app.ts"
        ],
        cache: {},
        packageCache: {}
    })
        .plugin(tsify);

    let stream = bundler.bundle()
        .pipe(source("app.js"))
        .pipe(buffer())
        .pipe(sourcemaps.init({ loadMaps: true }))
        .pipe(sourcemaps.write("./"))
        .pipe(gulp.dest("wwwroot/dist"));

    return stream;
});
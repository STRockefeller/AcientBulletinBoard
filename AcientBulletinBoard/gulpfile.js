var debug = false;

var gulp = require("gulp");
var uglify = require("gulp-uglify");
var browserify = require("browserify");
var source = require('vinyl-source-stream');
var tsify = require("tsify");
var gutil = require("gulp-util");
var buffer = require('vinyl-buffer');
var del = require("del");
var htmlreplace = require('gulp-html-replace');
var htmlmin = require("gulp-htmlmin");
var cssmin = require("gulp-cssmin");
var rename = require('gulp-rename');

var tsProject = {
    "noImplicitAny": false,
    "noEmitOnError": true,
    "removeComments": true,
    "sourceMap": false,
    "target": "es5"
};
if (debug) {
    tsProject = {
        "noImplicitAny": false,
        "noEmitOnError": true,
        "removeComments": false,
        "sourceMap": true,
        "target": "es5"
    };
}

var files = {
    min_js: [
        "./node_modules/jquery/dist/jquery.min.js"
        , "./node_modules/jquery-ui-npm/jquery-ui.min.js"
        , "./node_modules/bootstrap/dist/js/bootstrap.bundle.min.js"
        , "./node_modules/moment/min/moment.min.js"
        , "./node_modules/moment/min/moment-with-locales.min.js"
        , "./node_modules/moment-timezone/builds/moment-timezone.min.js"
        , "./node_modules/moment-timezone/builds/moment-timezone-with-data-1970-2030.min.js"
        , "./node_modules/@microsoft/signalr/dist/browser/signalr.min.js"
        , "./node_modules/pc-bootstrap4-datetimepicker/build/js/bootstrap-datetimepicker.min.js"
        , "./node_modules/bootstrap-table/dist/bootstrap-table.min.js"
        , "./node_modules/bootstrap-table/dist/bootstrap-table-locale-all.min.js"
        , "./node_modules/bootstrap-treeview/dist/bootstrap-treeview.min.js"
        , "./node_modules/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.min.js"
        , "./node_modules/vis/dist/vis.min.js"
        , "./node_modules/vis/dist/vis-graph3d.min.js"
        , "./node_modules/vis/dist/vis-timeline-graph2d.min.js"
    ],
    js: [
        "./node_modules/jquery.cookie/jquery.cookie.js"
        , "./node_modules/jquery.ui.widget/jquery.ui.widget.js"
        , "./node_modules/blueimp-file-upload/js/jquery.iframe-transport.js"
        , "./node_modules/blueimp-file-upload/js/jquery.fileupload.js"
        , "./node_modules/jquery-file-download/src/Scripts/jquery.fileDownload.js"
    ],
    min_css: [
        "./node_modules/bootstrap/dist/css/bootstrap.min.css"
        , "./node_modules/@fortawesome/fontawesome-free/css/all.min.css"
        , "./node_modules/pc-bootstrap4-datetimepicker/build/css/bootstrap-datetimepicker.min.css"
        , "./node_modules/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.min.css"
        , "./node_modules/bootstrap-table/dist/bootstrap-table.min.css"
        , "./node_modules/bootstrap-treeview/dist/bootstrap-treeview.min.css"
        , "./node_modules/vis/dist/vis.min.css"
        , "./node_modules/vis/dist/vis-timeline-graph2d.min.css"
    ],
    css: [
        "./src/css/chevalier.css"
        , "./node_modules/blueimp-file-upload/css/jquery.fileupload.css"
    ],
    font: [
        "./node_modules/@fortawesome/fontawesome-free/webfonts/*.*"
    ]
};
var useFiles = {
    js: [
        "/js/jquery.min.js"
        , "/js/jquery.cookie.min.js"
        , "/js/bootstrap.bundle.min.js"
        , "/js/moment.min.js"
        , "/js/moment-with-locales.min.js"
        , "/js/signalr.min.js"
        , "/js/jquery.bootstrap-touchspin.min.js"
        , "/js/bootstrap-datetimepicker.min.js"
        , "/js/jquery.ui.widget.min.js"
        , "/js/jquery.iframe-transport.min.js"
        , "/js/jquery.fileupload.min.js"
        , "/js/jquery.fileDownload.min.js"
        , "/js/bootstrap-table.min.js"
        , "/js/bootstrap-table-locale-all.min.js"
        , "/js/bootstrap-treeview.min.js"
    ]
    , css: [
        "/css/all.min.css"
        , "/css/bootstrap.min.css"
        , "/css/bootstrap-datetimepicker.min.css"
        , "/css/jquery.bootstrap-touchspin.min.css"
        , "/css/jquery.fileupload.min.css"
        , "/css/bootstrap-table.min.css"
        , "/css/bootstrap-treeview.min.css"
        , "/css/chevalier.min.css"
    ]
    , css_chart: [
        "/css/vis.min.css"
        , "/css/vis-timeline-graph2d.min.css"
    ]
    , js_chart: [
        "/js/vis.min.js"
        , "/js/vis-graph3d.min.js"
        , "/js/vis-timeline-graph2d.min.js"
    ]
};
gulp.task("copy:clean", done => {
    del(["wwwroot/js"]);
    done();
});
gulp.task("copy:js", done => {
    gulp.src(files.js)
        .pipe(uglify())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest("./wwwroot/js"));
    done();
});
gulp.task("ChatRoomIndex:js", function () {
    return browserify({
        basedir: ".",
        debug: debug,
        entries: ["./src/ChatRoomIndex.ts"],
        cache: {},
        packageCache: {}
    })
        .plugin(tsify, tsProject)
        .bundle()
        .pipe(source("ChatRoomIndex.js"))
        .pipe(debug ? gutil.noop() : buffer())
        .pipe(debug ? gutil.noop() : uglify())
        .pipe(gulp.dest("./wwwroot/js"));
});
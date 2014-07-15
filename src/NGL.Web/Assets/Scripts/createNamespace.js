var Ngl = Ngl || {};

Ngl.createNS = function (namespace) {
    var nsparts = namespace.split(".");
    var parent = Ngl;

    if (nsparts[0] === "Ngl") {
        nsparts = nsparts.slice(1);
    }

    for (var i = 0; i < nsparts.length; i++) {
        var partname = nsparts[i];
        if (typeof parent[partname] === "undefined") {
            parent[partname] = {};
        }
        parent = parent[partname];
    }

    return parent;
};
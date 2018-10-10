layui.define("jquery", function (i) {
    "use strict";
    var a = layui.$, t = layui.hint(), l = layui.device(), e = "larryElem", n = "layui-this", s = "layui-show",
        c = function () {
            this.config = {}
        };
    c.prototype.set = function (i) {
        var t = this;
        a.extend(true, t.config, i);
        return t
    };
    c.prototype.on = function (i, a) {
        return layui.onevent.call(this, e, i, a)
    };
    c.prototype.tabAdd = function (i, t) {
        var l = ".layui-tab-title", e = a(".layui-tab[lay-filter=" + i + "]"), n = e.children(l),
            s = e.children(".layui-tab-content");
        n.append('<li lay-id="' + (t.id || "") + '">' + (t.title || "unnaming") + "</li>");
        s.append('<div class="layui-tab-item">' + (t.content || "") + "</div>");
        return this
    };
    c.prototype.tabDelete = function (i, t) {
        var l = ".layui-tab-title", e = a(".layui-tab[lay-filter=" + i + "]"), n = e.children(l),
            s = n.find('>li[lay-id="' + t + '"]');
        p.tabDelete(null, s);
        return this
    };
    c.prototype.tabChange = function (i, t) {
        var l = ".layui-tab-title", e = a(".layui-tab[lay-filter=" + i + "]"), n = e.children(l),
            s = n.find('>li[lay-id="' + t + '"]');
        p.tabClick(null, null, s);
        return this
    };
    c.prototype.progress = function (i, t) {
        var l = "layui-progress", e = a("." + l + "[lay-filter=" + i + "]"), n = e.find("." + l + "-bar"),
            s = n.find("." + l + "-text");
        n.css("width", t);
        s.text(t);
        return this
    };
    var o = ".layui-nav", r = "layui-nav-item", u = "layui-nav-bar", d = "layui-nav-tree", f = "layui-nav-child",
        h = "layui-nav-more", y = "layui-anim layui-anim-upbit", p = {
            tabClick: function (i, t, l) {
                var c = l || a(this), t = t || c.parent().children("li").index(c), o = c.parents(".layui-tab").eq(0),
                    r = o.children(".layui-tab-content").children(".layui-tab-item"), u = c.find("a"),
                    d = o.attr("lay-filter");
                if (!(u.attr("href") !== "javascript:;" && u.attr("target") === "_blank")) {
                    c.addClass(n).siblings().removeClass(n);
                    r.eq(t).addClass(s).siblings().removeClass(s)
                }
                layui.event.call(this, e, "tab(" + d + ")", {elem: o, index: t})
            }, tabDelete: function (i, t) {
                var l = t || a(this).parent(), e = l.index();
                var s = l.parents(".layui-tab").eq(0);
                var c = s.children(".layui-tab-content").children(".layui-tab-item");
                if (l.hasClass(n)) {
                    if (l.next()[0]) {
                        p.tabClick.call(l.next()[0], null, e + 1)
                    } else if (l.prev()[0]) {
                        p.tabClick.call(l.prev()[0], null, e - 1)
                    }
                }
                l.remove();
                c.eq(e).remove()
            }, clickThis: function () {
                var i = a(this), t = i.parents(o), l = t.attr("lay-filter"), s = i.find("a");
                if (i.find("." + f)[0])return;
                if (!(s.attr("href") !== "javascript:;" && s.attr("target") === "_blank")) {
                    t.find("." + n).removeClass(n);
                    i.addClass(n)
                }
                layui.event.call(this, e, "nav(" + l + ")", i)
            }, clickChild: function () {
                var i = a(this), t = i.parents(o), l = t.attr("lay-filter");
                t.find("." + n).removeClass(n);
                i.addClass(n);
                layui.event.call(this, e, "nav(" + l + ")", i)
            }, showChild: function () {
                var i = a(this), t = i.parents(o);
                var l = i.parent(), e = i.siblings("." + f);
                if (t.hasClass(d)) {
                    e.removeClass(y);
                    l[e.css("display") === "none" ? "addClass" : "removeClass"](r + "ed")
                }
            }, collapse: function () {
                var i = a(this), t = i.find(".layui-colla-icon"), l = i.siblings(".layui-colla-content"),
                    n = i.parents(".layui-collapse").eq(0), c = n.attr("lay-filter"), o = l.css("display") === "none";
                if (typeof n.attr("lay-accordion") === "string") {
                    var r = n.children(".layui-colla-item").children("." + s);
                    r.siblings(".layui-colla-title").children(".layui-colla-icon").html("&#xe602;");
                    r.removeClass(s)
                }
                l[o ? "addClass" : "removeClass"](s);
                t.html(o ? "&#xe61a;" : "&#xe602;");
                layui.event.call(this, e, "collapse(" + c + ")", {title: i, content: l, show: o})
            }
        };
    c.prototype.init = function (i) {
        var t = this, e = {
            nav: function () {
                var i = 200, t = {}, e = {}, n = {}, c = function (c, o, r) {
                    var u = a(this), p = u.find("." + f);
                    if (o.hasClass(d)) {
                        c.css({top: u.position().top, height: u.children("a").height(), opacity: 1})
                    } else {
                        p.addClass(y);
                        c.css({
                            left: u.position().left + parseFloat(u.css("marginLeft")),
                            top: u.position().top + u.height() - 5
                        });
                        t[r] = setTimeout(function () {
                            c.css({width: u.width(), opacity: 1})
                        }, l.ie && l.ie < 10 ? 0 : i);
                        clearTimeout(n[r]);
                        if (p.css("display") === "block") {
                            clearTimeout(e[r])
                        }
                        e[r] = setTimeout(function () {
                            p.addClass(s);
                            u.find("." + h).addClass(h + "d")
                        }, 300)
                    }
                };
                a(o).each(function (l) {
                    var o = a(this), y = a('<span class="' + u + '"></span>'), v = o.find("." + r);
                    if (!o.find("." + u)[0]) {
                        o.append(y);
                        v.on("mouseenter", function () {
                            c.call(this, y, o, l)
                        }).on("mouseleave", function () {
                            if (!o.hasClass(d)) {
                                clearTimeout(e[l]);
                                e[l] = setTimeout(function () {
                                    o.find("." + f).removeClass(s);
                                    o.find("." + h).removeClass(h + "d")
                                }, 300)
                            }
                        });
                        o.on("mouseleave", function () {
                            clearTimeout(t[l]);
                            n[l] = setTimeout(function () {
                                if (o.hasClass(d)) {
                                    y.css({height: 0, top: y.position().top + y.height() / 2, opacity: 0})
                                } else {
                                    y.css({width: 0, left: y.position().left + y.width() / 2, opacity: 0})
                                }
                            }, i)
                        })
                    }
                    v.each(function () {
                        var i = a(this), t = i.find("." + f);
                        if (t[0] && !i.find("." + h)[0]) {
                            var l = i.children("a");
                            l.append('<span class="' + h + '"></span>')
                        }
                        i.off("click", p.clickThis).on("click", p.clickThis);
                        i.children("a").off("click", p.showChild).on("click", p.showChild);
                        t.children("dd").off("click", p.clickChild).on("click", p.clickChild)
                    })
                })
            }, breadcrumb: function () {
                var i = ".layui-breadcrumb";
                a(i).each(function () {
                    var i = a(this), t = i.attr("lay-separator") || ">", l = i.find("a");
                    if (l.find(".layui-box")[0])return;
                    l.each(function (i) {
                        if (i === l.length - 1)return;
                        a(this).append('<span class="layui-box">' + t + "</span>")
                    });
                    i.css("visibility", "visible")
                })
            }, progress: function () {
                var i = "layui-progress";
                a("." + i).each(function () {
                    var t = a(this), l = t.find(".layui-progress-bar"), e = l.attr("lay-percent");
                    l.css("width", e);
                    if (t.attr("lay-showPercent")) {
                        setTimeout(function () {
                            var a = Math.round(l.width() / t.width() * 100);
                            if (a > 100) a = 100;
                            l.html('<span class="' + i + '-text">' + a + "%</span>")
                        }, 350)
                    }
                })
            }, collapse: function () {
                var i = "layui-collapse";
                a("." + i).each(function () {
                    var i = a(this).find(".layui-colla-item");
                    i.each(function () {
                        var i = a(this), t = i.find(".layui-colla-title"), l = i.find(".layui-colla-content"),
                            e = l.css("display") === "none";
                        t.find(".layui-colla-icon").remove();
                        t.append('<i class="layui-icon layui-colla-icon">' + (e ? "&#xe602;" : "&#xe61a;") + "</i>");
                        t.off("click", p.collapse).on("click", p.collapse)
                    })
                })
            }
        };
        return layui.each(e, function (i, a) {
            a()
        })
    };
    var v = new c, b = a(document);
    v.init();
    var m = ".layui-tab-title li";
    b.on("click", m, p.tabClick);
    i(e, v)
});
function select_tamagotchi_item(tamagotchi_id) {
    var selected_ids = document.getElementById("selected-tamagotchis_id").value;
    var ids_array = selected_ids.split(',');

    var index = indexOf(ids_array, tamagotchi_id);
    if (index > -1) {
        ids_array[index] = null;
        document.getElementById("selected-tamagotchis_id").value = "";
        for (var x = 0; x < ids_array.length; x++) {
            if (ids_array[x] != null) {
                document.getElementById("selected-tamagotchis_id").value += ids_array[x] + ',';
            }
        }

        if (document.getElementById("selected-tamagotchis_id").value.length > 0) {
            document.getElementById("selected-tamagotchis_id").value = document.getElementById("selected-tamagotchis_id").value.slice(0, -1);
        }
    } else {
        var left_selection = document.getElementById("selected-tamagotchis_count").value;
        if (left_selection > 0) {
            if (selected_ids == "") {
                document.getElementById("selected-tamagotchis_id").value = tamagotchi_id;
            } else {
                document.getElementById("selected-tamagotchis_id").value += ',' + tamagotchi_id;
            }
        }
    }

}

function indexOf(array, item) {
    for (var i = 0; i < array.length; i++) {
        if (array[i].toString() === item.toString()) return i;
    }
    return -1;
}

function check_submit_count(event) {
    event = event || window.event || event.srcElement;
    if (document.getElementById("selected-tamagotchis_id").value.length > 0) {
        return document.room_submit.submit();
    } else {
        event.preventDefault();
    }

}


+function ($) {
    "use strict";


    // LISTGROUP PUBLIC CLASS DEFINITION
    // =======================
    var ListGroup = function (element, options) {
        this.$element = $(element);
        this.options = options || {};
        this.init();
    };

    ListGroup.prototype.init = function () {
        var me = this;
        var $element = this.$element;
        var options = this.options;

        if (options.toggle)
            $element.attr('data-toggle', options.toggle);

        $element.on('click', '.list-group-item', function () {
            var $item = $(this);

            if (!$item.hasClass('disabled')) {

                if ($element.data('toggle') == 'items') {
                    if ($item.hasClass('active')) {
                        // disable select
                        document.getElementById("selected-tamagotchis_count").value++;
                        $item.toggleClass('active');
                    } else {
                        // enable select
                        var left_selection = document.getElementById("selected-tamagotchis_count").value;
                        if (left_selection > 0) {
                            document.getElementById("selected-tamagotchis_count").value--;
                            $item.toggleClass('active');
                        }
                    }


                }
                else {
                    me.unselect('*')
                        .select($item);
                }


                if (options.click)
                    options.click.apply(this);
            }

            $item.blur();
            return false;
        });
    };

    ListGroup.prototype.select = function (item) {
        if (item instanceof $)
            item.addClass('active');

        if (typeof item === 'string')
            item = [item];

        if (Array.isArray(item)) {
            for (var i in item) {
                var val = item[i];
                this.$element
                    .find('.list-group-item[data-value=\'' + val + '\']')
                    .addClass('active');
            }
        }
        return this;
    };

    ListGroup.prototype.unselect = function (selector) {
        this.$element
            .find('.list-group-item')
            .filter(selector || '*')
            .removeClass('active');
        return this;
    };


    // SELECTLIST PUBLIC CLASS DEFINITION
    // =======================
    var SelectList = function (element, options) {
        this.$element = $(element);
        this.options = options;
        this.$listGroup = this.createListGroup();
    };

    SelectList.prototype.select = function (values) {
        if (values instanceof $) {
            var vals = [];
            values.each(function (i, element) {
                vals.push($(element).val());
            });
            values = vals;
        }

        this.$element.val(values)
            .change();
    };

    SelectList.prototype.unselect = function (values) {
        var value = this.$element.val();

        if (!Array.isArray(value)) value = [value];
        if (!Array.isArray(values)) values = [values];

        for (var i in values)
            value.pop(values[i]);

        this.$element.val(value)
            .change();
    };

    SelectList.prototype.createListGroup = function () {
        var $select = this.$element;

        var $listGroup = $('<ul>').addClass('list-group');

        if ($select.attr('multiple'))
            $listGroup.attr('data-toggle', 'items');

        $select.find('option').each(function (i, item) {
            var $item = $(item);

            var $new = $('<a>')
                .attr('href', '#')
                .addClass('list-group-item')
                .attr('data-value', $item.val())
                .text($item.text());

            if ($item.is(':disabled'))
                $new.addClass('disabled');

            if ($item.css('display') === 'none')
                $new.addClass('hidden');

            $listGroup.append($new);
        });

        $select.change(function () {
            $listGroup.listgroup({
                unselect: '*',
                select: $select.val()
            });
        });

        $listGroup.listgroup({
            select: $select.val(),
            click: function () {
                var values = [];
                $listGroup.find('.list-group-item.active').each(function (i, item) {
                    var value = $(item).data('value');
                    values.push(value);
                });
                if (values.length == 1) values = values[0];
                $select.val(values);
            }
        });
        $select.before($listGroup);
        this.$listGroup = $listGroup;

        $select.hide();

        return $listGroup;
    };


    // LIST GROUP PLUGIN DEFINITION
    // =======================
    $.fn.listgroup = function (option) {
        return this.each(function (i, element) {
            var $element = $(element);

            var list = $element.data('listgroup');
            if (!list)
                $element.data('listgroup', (list = $element.is('select')
                    ? new SelectList(element, option)
                    : new ListGroup(element, option)));

            if (option) {

                if (option.unselect)
                    list.unselect(option.unselect);

                if (option.select)
                    list.select(option.select);
            }
        });
    };

    $(function () {
        $('.list-group').listgroup();
    });
}(jQuery);
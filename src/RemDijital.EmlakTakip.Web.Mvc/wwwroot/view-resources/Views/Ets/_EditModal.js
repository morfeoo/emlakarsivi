(function ($) {
    var _roleService = abp.services.app.et,
        l = abp.localization.getSource('EmlakTakip'),
        _$modal = $('#RoleEditModal'),
        _$form = _$modal.find('form');

    function save() {
        if (!_$form.valid()) {
            return;
        }

        var role = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);
        _roleService.etUpdate(role).done(function (result) {
            if (result == true) {
                _$modal.modal('hide');
                abp.event.trigger('et.edited', role);
                abp.notify.info(l('SavedSuccessfully'));
            } else {
                abp.notify.info(l('SaveNotSuccessfull'));
            }
        }).always(function () {
            abp.ui.clearBusy(_$form);
        });
    }

    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);

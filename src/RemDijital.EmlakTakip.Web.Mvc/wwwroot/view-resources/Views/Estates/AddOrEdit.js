(function ($) {
    var _estateService = abp.services.app.estate,
        l = abp.localization.getSource('EmlakTakip'),
        _$modal = $('.AddOrEditModal'),
        _$form = _$modal.find('form');
        //_$table = $('#EstateTable');
    debugger;

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();
        debugger;
        if (!_$form.valid()) {
            return;
        }

        var user = _$form.serializeFormToObject();
        debugger;

        abp.ui.setBusy(_$modal);
        _estateService.estateAddOrEdit(user).done(function (data) {
            //_$modal.modal('hide');
            if (data == true) {
                //_$form[0].reset();
                //$('#estateAddOrEditForm').not(':button, :submit, :reset, :hidden').val('').removeAttr('checked').removeAttr('selected');
                //$("#estateAddOrEditForm").trigger('reset');

                abp.notify.success(l('SavedSuccessfully'));
            }
            else {
                abp.notify.error(l('SaveNotSuccessfull'));
            }
            //_$usersTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.edit-user', function (e) {
        var userId = $(this).attr("data-user-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Users/EditModal?userId=' + userId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#UserEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });

    $(document).on('click', 'a[data-target="#UserCreateModal"]', (e) => {
        $('.nav-tabs a[href="#user-details"]').tab('show')
    });

    abp.event.on('user.edited', (data) => {
        _$usersTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$estateTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$estateTable.ajax.reload();
            return false;
        }
    });
})(jQuery);

(function ($) {
    var _etService = abp.services.app.et,
        l = abp.localization.getSource('EmlakTakip'),
        _$modal = $('#EstateTypeCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#UsersTable');

    var _$estateTypesTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#EtsSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;
            console.log("1")
            abp.ui.setBusy(_$table);
            debugger;
            _etService.filter(filter).done(function (result) {
                debugger;
                console.log(result)
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).fail(function (result) {
                debugger;

                console.log(result)
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).catch(function (result) {
                debugger;

                console.log(result)
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function (d) {
                debugger;

                abp.ui.clearBusy(_$table);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$estateTypesTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'name',
                sortable: false
            },
            {
                targets: 2,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-et" data-user-id="${row.id}" data-toggle="modal" data-target="#EtEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-et" data-user-id="${row.id}" data-et-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    _$form.validate({
        rules: {
            Password: "required",
            ConfirmPassword: {
                equalTo: "#Password"
            }
        }
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var user = _$form.serializeFormToObject();
        user.roleNames = [];
        var _$roleCheckboxes = _$form[0].querySelectorAll("input[name='role']:checked");
        if (_$roleCheckboxes) {
            for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
                var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
                user.roleNames.push(_$roleCheckbox.val());
            }
        }

        abp.ui.setBusy(_$modal);
        _userService.create(user).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$usersTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-user', function () {
        var userId = $(this).attr("data-user-id");
        var userName = $(this).attr('data-user-name');

        deleteUser(userId, userName);
    });

    function deleteUser(userId, userName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                userName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _userService.delete({
                        id: userId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$usersTable.ajax.reload();
                    });
                }
            }
        );
    }

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
        _$estateTypesTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$usersTable.ajax.reload();
            return false;
        }
    });
})(jQuery);

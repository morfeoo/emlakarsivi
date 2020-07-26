(function ($) {
    var _estateService = abp.services.app.estate,
        _userService = abp.services.app.user,
        l = abp.localization.getSource('EmlakTakip'),
        _$modal = $('#EstateCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#EstateTable');

    var _$estateTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#EstatesSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;
            console.log("1")
            abp.ui.setBusy(_$table);
            _estateService.filter(filter).done(function (result) {
                console.log(result.items)
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).fail(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).catch(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function (d) {
                abp.ui.clearBusy(_$table);
            });
        },
        buttons: [
            //{
            //    name: 'refresh',
            //    text: '<i class="fas fa-redo-alt"></i>',
            //    action: () => _$estateTable.draw(false)
            //}
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
                data: 'price',
                sortable: false
            },
            {
                targets: 3,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    if (row.creatorUserId != 0) {
                        return [
                            `   <button type="button" class="btn btn-sm bg-secondary" href="Estate/AddOrEdit?id=${row.id}">`,
                            `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                            '   </button>',
                            `      <button type="button" class="btn btn-sm bg-danger delete-estate" data-estate-id="${row.id}" data-estate-name="${row.name}">`,
                            `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                            '   </button>'
                        ].join('');
                    }
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

        abp.ui.setBusy(_$modal);
        _estateService.create(user).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$usersTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-estate', function () {
        var estateId = $(this).attr("data-estate-id");
        var estateName = $(this).attr('data-estate-name');

        deleteEstate(estateId, estateName);
    });

    function deleteEstate(estateId, estateName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                estateName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _estateService.delete({
                        id: estateId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$estateTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-estate', function (e) {
        var userId = $(this).attr("data-estate-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Estate/AddOrEdit?id=' + userId,
            type: 'GET',
            success: function (content) {
                window.location.href = "Estate/AddOrEdit?id=" + content.id;
            },
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

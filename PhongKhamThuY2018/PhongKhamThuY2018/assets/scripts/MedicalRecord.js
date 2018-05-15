$(document).ready(function () {

    LoadCategoryMedicalForAddItem();
    LoadMedicalForAddItem();
    LoadChangedMedicalByCategory();
    LoadChangedMedical();

    ValidationFormSelectedPet();
    ValidationFormAddingPet();

    function ValidationFormSelectedPet() {

        $('#namePetErrorMessage').hide();
        $('#kindPetErrorMessage').hide();

        var errorNamePet = false;
        var errorKindPet = false;

        $('input[name="SearchPetName"]').focusout(function () {

            var SearchNamePetLength = $('input[name="SearchPetName"]').val().length;

            if (SearchNamePetLength == "") {
                $('#namePetErrorMessage').show();
                errorNamePet = true;
            } else {
                $('#namePetErrorMessage').hide();
                errorNamePet = false;
            }
        });

        $('input[name="SearchPetKind"]').focusout(function () {

            var SearchKindPetLength = $('input[name="SearchPetKind"]').val().length;

            if (SearchKindPetLength == "") {
                $('#kindPetErrorMessage').show();
                errorKindPet = true;
            } else {
                $('#kindPetErrorMessage').hide();
                errorKindPet = false;
            }
        });


        $('#btn-search-pet').click(function () {

            if (errorNamePet === false && errorKindPet === false) {

                var name = $('input[name="SearchPetName"]').val();
                var kind = $('input[name="SearchPetKind"]').val();

                //Xóa table SearchPetTable trc để khỏi bị trùng dữ liệu
                $('#SearchPetTable tr').remove();

                //get pet trong db để search
                $.ajax({
                    type: "POST",
                    url: "/MedicalRecord/SearchingListPet?namePet=" + name + "&nameKind=" + kind + "",
                    success: function (pet) {

                        var tong = 0;
                        $.each(pet, function (index, value) {

                            var tr = ' <tr><td>' + value.TENTHU + '</td> <td>' + value.TENKH + '</td> <td>' + value.LOAI + '</td><td>' + value.MAULONG + '</td><td>' + value.GIOITINH + '</td><td><div class="form-check form-check-inline"><input class="form-check-input" type="radio" name="SelectedPet" id="SelectedPet" value="' + value.MATHU + '"></div></td></tr>';

                            $('#SearchPetTable').append(tr);

                            tong++;
                        });

                        $.notify("Tìm thấy " + tong + " thú cưng", { position: "top", autoHideDelay: 2000, className: "info" });
                    },
                    error: function (error) {
                        alert("thua chọn pet" + error);
                    }
                })
            }
            else {
                //Không làm gì
            }

        });

    }

    function ValidationFormAddingPet() {

        $('#namePetAddingErrorMessage').hide();
        $('#skinPetAddingErrorMessage').hide();
        $('#kindPetAddingErrorMessage').hide();


        $('#nameCustomerAddingErrorMessage').hide();
        $('#phoneCustomerAddingErrorMessage').hide();
        $('#addressCustomerAddingErrorMessage').hide();


        var errorNamePet = false;
        var errorKindPet = false;
        var errorSkinPet = false;

        var errorNameCustomer = false;
        var errorPhoneCustomer = false;
        var errorAddressCustomer = false;

        $('input[name="CustomerName"]').focusout(function () {

            var NameLength = $('input[name="CustomerName"]').val().length;

            if (NameLength == "") {
                $('#nameCustomerAddingErrorMessage').show();
                errorNameCustomer = true;
            } else {
                $('#nameCustomerAddingErrorMessage').hide();
                errorNameCustomer = false;
            }
        });

        $('input[name="CustomerPhone"]').focusout(function () {

            var PhoneLength = $('input[name="CustomerPhone"]').val().length;

            if (PhoneLength == "") {
                $('#phoneCustomerAddingErrorMessage').show();
                errorPhoneCustomer = true;
            } else {
                $('#phoneCustomerAddingErrorMessage').hide();
                errorPhoneCustomer = false;
            }
        });

        $('input[name="CustomerAddress"]').focusout(function () {

            var AddressLength = $('input[name="CustomerAddress"]').val().length;

            if (AddressLength == "") {
                $('#addressCustomerAddingErrorMessage').show();
                errorAddressCustomer = true;
            } else {
                $('#addressCustomerAddingErrorMessage').hide();
                errorAddressCustomer = false;
            }
        });

        $('input[name="PetName"]').focusout(function () {

            var NamePetLength = $('input[name="PetName"]').val().length;

            if (NamePetLength == "") {
                $('#namePetAddingErrorMessage').show();
                errorNamePet = true;
            } else {
                $('#namePetAddingErrorMessage').hide();
                errorNamePet = false;
            }
        });

        $('input[name="PetKind"]').focusout(function () {

            var KindPetLength = $('input[name="PetKind"]').val().length;

            if (KindPetLength == "") {
                $('#kindPetAddingErrorMessage').show();
                errorKindPet = true;
            } else {
                $('#kindPetAddingErrorMessage').hide();
                errorKindPet = false;
            }
        });

        $('input[name="PetSkin"]').focusout(function () {

            var SkinPetLength = $('input[name="PetSkin"]').val().length;

            if (SkinPetLength == "") {
                $('#skinPetAddingErrorMessage').show();
                errorSkinPet = true;
            } else {
                $('#skinPetAddingErrorMessage').hide();
                errorSkinPet = false;
            }
        });

        $('#btn-add-customer').click(function () {
            if (errorNamePet === false && errorKindPet === false && errorSkinPet === false
                && errorAddressCustomer == false && errorPhoneCustomer === false && errorAddressCustomer === false
                ) {
                var name = $('input[name="CustomerName"]').val();
                var phone = $('input[name="CustomerPhone"]').val();
                var address = $('input[name="CustomerAddress"]').val();
                var gender = $('input[name="CustomerGender"]:checked').val();

                var customer = {
                    TEN: name,
                    SDT: phone,
                    DIACHI: address,
                    GIOITINH: gender
                };

                var name = $('input[name="PetName"]').val();
                var skin = $('input[name="PetSkin"]').val();
                var kind = $('input[name="PetKind"]').val();
                var gender = $('input[name="PetGender"]:checked').val();


                //thêm khách hàng thành công thì mới lấy dc cái ID r add vào column MaKhach của Pet
                $.ajax({
                    type: "POST",
                    url: "/MedicalRecord/InsertCustomer",
                    data: customer,
                    success: function (customer) {

                        //gửi thêm cái idkhach
                        var pet = {
                            TENTHU: name,
                            LOAI: kind,
                            MAULONG: skin,
                            GIOITINH: gender,
                            MAKH: customer.MAKH
                        };

                        $.ajax({
                            type: "POST",
                            url: "/MedicalRecord/InsertPet",
                            data: pet,
                            success: function (pet) {
                                $.notify("Thêm thú cưng thành công", { position: "top", autoHideDelay: 2000, className: "success" });

                                $('input[name="CurrentPetId"]').val(pet.MATHU);

                                $('input[name="CurrentPetName"]').val(pet.TENTHU);
                                $('input[name="CurrentPetSkin"]').val(pet.MAULONG);
                                $('input[name="CurrentPetKind"]').val(pet.LOAI);
                                $("input[name='CurrentPetGender'][value=" + pet.GIOITINH + "]").attr('checked', 'checked');
                            },
                            error: function (pet) {
                                alert("thua PET");
                            }
                        });

                        $('input[name="CurrentCustomerName"]').val(customer.TEN);
                        $('input[name="CurrentCustomerPhone"]').val(customer.SDT);
                        $('input[name="CurrentCustomerAddress"]').val(customer.DIACHI);
                        $("input[name='CurrentCustomerGender'][value=" + customer.GIOITINH + "]").attr('checked', 'checked');
                    },
                    error: function (customer) {
                        alert("thua CUSTOMER");
                    }
                })
            }
            else {
                //Không làm gì
            }

        });
    }

    function LoadCategoryMedicalForAddItem() {
        var categoryMedicalOptions;
        $.getJSON('/MedicalRecord/GetListCategoryMedical', function (data) {
            categoryMedicalOptions += "<option>--Chọn loại thuốc--</option>"
            $.each(data, function (i, categoryMedical) {
                categoryMedicalOptions += "<option value='" + categoryMedical.MALOAITHUOC + "'>" + categoryMedical.TENLOAITHUOC + "</option>";
            });

            $('#CategoryMedical').html(categoryMedicalOptions);

        });
    }

    function LoadMedicalForAddItem() {

        var MedicalOptions;
        $.getJSON('/MedicalRecord/GetListMedicalForAddItem', function (data) {
            MedicalOptions += "<option>--Chọn loại thuốc--</option>"
            //dùng append()  jquery cũng dc
            $.each(data, function (i, Medical) {
                MedicalOptions += "<option value='" + Medical.MATHUOC + "'>" + Medical.TENTHUOC + "</option>";
            });

            $("#MedicalName").html(MedicalOptions);
        });
    }

    function LoadChangedMedicalByCategory() {

        $("#CategoryMedical").change(function () {

            $.getJSON('/MedicalRecord/GetListMedicalByCategory', { idLoaiThuoc: $('#CategoryMedical').val() }, function (data) {

                $('#MedicalName').empty();

                $('#MedicalName').append("<option>--Chọn loại thuốc--</option>");

                $.each(data, function (i, Medical) {
                    console.log(Medical)
                    $('#MedicalName').append("<option value='" + Medical.MATHUOC + "'>" + Medical.TENTHUOC + "</option>");
                });
            });
        });
    }

    function LoadChangedMedical() {

        $("#MedicalName").change(function () {

            $.getJSON('/MedicalRecord/GetMedicalById', { idMedical: $('#MedicalName').val() }, function (data) {


                $('input[name="MedicalQuantity"]').val("");
                $('input[name="MedicalNote"]').val("");

                $('input[name="MedicalId"]').val(data.MATHUOC);
                $('input[name="MedicalUnit"]').val(data.TENDONVI);
                $('input[name="MedicalPrice"]').val(data.DONGIA);
                $('input[name="MedicalInstruction"]').val(data.HUONGDANSUDUNG);
            });
        });
    }

    //$('#CurrentPetID').autocomplete({
    //    source: function (request, response) {

    //        var text = $('#CurrentPetID').val();

    //        $.ajax({

    //            type: "GET",
    //            url: "/MedicalRecord/GetListMedical",
    //            data: { text: request.term },
    //            success: function (data) {

    //                response($.map(data, function (item) {
    //                    return { label: item, value: item }
    //                }))
    //            }

    //        })
    //    }
    //});

    $('#btn-select-pet').click(function () {
        var idSelectedPet = $('input[name="SelectedPet"]:checked').val();

        //get pet trong db để search
        $.ajax({
            type: "POST",
            url: "/MedicalRecord/GetSelectedPet?idPet=" + idSelectedPet + "",
            success: function (data) {

                $.notify("Chọn thú cưng " + data.TENTHU + " thành công", { position: "top", autoHideDelay: 2000, className: "success" });


                $('input[name="CurrentPetId"]').val(data.MATHU);
                $('input[name="CurrentPetName"]').val(data.TENTHU);
                $('input[name="CurrentPetSkin"]').val(data.MAULONG);
                $('input[name="CurrentPetKind"]').val(data.LOAI);
                $("input[name='CurrentPetGender'][value=" + data.GIOITINH + "]").attr('checked', 'checked');

                $('input[name="CurrentCustomerName"]').val(data.TENKH);
                $('input[name="CurrentCustomerPhone"]').val(data.SDT);
                $('input[name="CurrentCustomerAddress"]').val(data.DIACHIKH);
                $("input[name='CurrentCustomerGender'][value=" + data.GIOITINHKH + "]").attr('checked', 'checked');

            },
            error: function (error) {
                alert("thua chọn pet" + error);
            }
        });
    });


    Number.prototype.formatMoney = function (c, t) {
        var n = this,
        c = isNaN(c = Math.abs(c)) ? 2 : c,
        t = t == undefined ? "," : t,
        s = n < 0 ? "-" : "",
        i = String(parseInt(n = Math.abs(Number(n) || 0).toFixed(c))),
        j = (j = i.length) > 3 ? j % 3 : 0;
        return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t);
    };

    function AdditionMedicalTotalPrice() {

        var quantity = $('input[name="MedicalQuantity"]').val();
        var price = $('input[name="MedicalPrice"]').val();

        var medicalTotalPrice = Number($('input[name="HiddenMedicalTotalPrice"]').val());
        medicalTotalPrice += (Number(quantity) * Number(price));

        setMedicalTotalPrice(medicalTotalPrice);
    }

    function isDuplicate(Duplicate, id, quantity) {

        Duplicate = false;
        $('#AddingMedicalToPrescription').find('tr').each(function (i, el) {

            var $tds = $(this).find('td'),
               medicalId = $tds.eq(0).text(),
                curQuantity = $tds.find('#AddingMedicalQuantity').val();

            if (medicalId == id) {
                Duplicate = true;

                var newQuantity = Number(quantity) + Number(curQuantity);

                $tds.find('#AddingMedicalQuantity').val(newQuantity);
                $tds.find('#prevValueQuantity').val(newQuantity);
            }

        });

        return Duplicate;
    }

    function AdditionTotalPrice() {
        var totalPrice = Number($('input[name="HiddenMedicalTotalPrice"]').val()) + Number($('input[name="HiddenExaminePrice"]').val());
        $('input[name="TotalPrice"]').val(totalPrice.formatMoney(2, '.'));
    }

    function setMedicalTotalPrice(medicalTotalPrice) {
        $('input[name="HiddenMedicalTotalPrice"]').val(medicalTotalPrice);
        $('input[name="MedicalTotalPrice"]').val(Number(medicalTotalPrice).formatMoney(2, '.'));
    }

    $('#btn-add-medical').click(function () {

        var id = $('#MedicalId').val(),
            name = $('#MedicalName option:selected').text(),
            category = $('#CategoryMedical option:selected').text(),
            unit = $('input[name="MedicalUnit"]').val(),
            quantity = $('input[name="MedicalQuantity"]').val(),
            price = $('input[name="MedicalPrice"]').val(),
            instruction = $('input[name="MedicalInstruction"]').val(),
            note = $('input[name="MedicalNote"]').val(),

            rowTable = $('#AddingMedicalToPrescription').find('tr').length;

        if (rowTable == 0) {
            var tr = ' <tr><td>' + id + '</td><td>' + name + '</td><td>' + category + '</td> <td>' + unit + '</td> <td><div class="col-5"><input type="hidden" value="' + quantity + '" id="prevValueQuantity"/><input class="form-control" type="number" min="1" value="' + quantity + '" id="AddingMedicalQuantity" /></div></td><td>' + price + '</td> <td>' + instruction + '</td><td>' + note +
                '</td><td><a  class="btn btn-sm btn-danger" id="deleteMedical"><i class="fa fa-trash"></i></a></td></tr>';

            $('#AddingMedicalToPrescription').append(tr);
        } else {

            var Duplicate = false;

            Duplicate = isDuplicate(Duplicate, id, quantity);

            if (Duplicate === false) {
                var tr = ' <tr><td>' + id + '</td><td>' + name + '</td><td>' + category + '</td> <td>' + unit + '</td> <td><div class="col-5"><input type="hidden" value="' + quantity + '" id="prevValueQuantity"/><input class="form-control" type="number" name="AddingMedicalQuantity" min="1" value="' + quantity + '" id="AddingMedicalQuantity" /></div></td><td>' + price + '</td> <td>' + instruction + '</td><td>' + note +
               '</td><td><a  class="btn btn-sm btn-danger" id="deleteMedical"><i class="fa fa-trash"></i></a></td></tr>';

                $('#AddingMedicalToPrescription').append(tr);
            }

        }

        AdditionMedicalTotalPrice();

        AdditionTotalPrice();
    });

    $('#AddingMedicalToPrescription').on('click', '#deleteMedical', function () {
        $(this).closest('tr').remove();

        var $row = $(this).closest("tr"),       // Finds the closest row <tr> 
        $tds = $row.find("td");             // Finds all children <td> elements

        var quantity = $tds.find('#AddingMedicalQuantity').val(),
         price = $tds.eq(5).text();

        var medicalTotalPrice = Number($('input[name="HiddenMedicalTotalPrice"]').val());

        medicalTotalPrice -= (quantity * Number(price));

        setMedicalTotalPrice(medicalTotalPrice);

        AdditionTotalPrice();
    })

    $('#AddingMedicalToPrescription').on('keyup mouseup', '#AddingMedicalQuantity', function () {

        var $row = $(this).closest("tr"),       // Finds the closest row <tr> 
         $tds = $row.find("td");             // Finds all children <td> elements

        var quantity = Number($tds.find('#AddingMedicalQuantity').val()),
         price = $tds.eq(5).text(),
         prevValueQuantity = Number($tds.find('#prevValueQuantity').val());

        var medicalTotalPrice = Number($('input[name="HiddenMedicalTotalPrice"]').val());

        if (quantity > prevValueQuantity) {
            medicalTotalPrice += (1 * Number(price));
        } else if (quantity < prevValueQuantity) {
            medicalTotalPrice -= (1 * Number(price));
        } else {

        }

        $tds.find('#prevValueQuantity').val(quantity);

        setMedicalTotalPrice(medicalTotalPrice);

        AdditionTotalPrice();

    })

    function getAllMedicalTable() {

        var medicals = [];

        // load all table
        $('#AddingMedicalToPrescription').find('tr').each(function (i, el) {

            var $tds = $(this).find('td'),
                medicalId = $tds.eq(0).text(),
                medical = $tds.eq(1).text(),
                quantity = $tds.find('#prevValueQuantity').val(),
                 giatien = $tds.eq(5).text(),
                 ghichu = $tds.eq(7).text();

            var medical = {
                MATHUOC: medicalId,
                SOLUONG: quantity,
                MATOA: 0,
                GIATIEN: giatien,
                GHICHU: ghichu
            };


            medicals.push(medical);
        });

        return medicals;
    }

    function getCurrentDay() {

        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth() + 1; //January is 0!
        var yyyy = today.getFullYear();

        if (dd < 10) {
            dd = '0' + dd
        }

        if (mm < 10) {
            mm = '0' + mm
        }

        today = dd + '/' + mm + '/' + yyyy;

        return today;

    }


    $('#btn-save-medical-record').click(function () {

        var medicals = [];

        medicals = getAllMedicalTable();

        var tongtien = $('input[name="HiddenMedicalTotalPrice"]').val();

        var prescription = {
            NGAYKETOA: getCurrentDay(),
            TONGTIEN: tongtien
        };

        $.ajax({
            type: 'POST',
            url: '/MedicalRecord/InsertPrescription',
            data: prescription,
            success: function (prescription) {

                //thêm matoa vao tung chitiettoa
                medicals.forEach(function (element) {
                    element.MATOA = prescription.MATOATHUOC;
                });


                medicals = JSON.stringify({ 'medicals': medicals });


                $.ajax({
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    type: 'POST',
                    url: '/MedicalRecord/InsertDetailPrescription',
                    data: medicals,
                    success: function () {

                        var mathu = $('input[name="CurrentPetId"]').val(),
                         trieuchung = $('#Result').val(),
                         chandoan = $('#ResultSick').val(),
                         medicalRecord = {
                             MATHU: mathu,
                             BENH: chandoan,
                             TRIEUCHUNG: trieuchung,
                             MATOA: prescription.MATOATHUOC
                         };

                        $.ajax({
                            type: 'POST',
                            url: '/MedicalRecord/InsertMedicalRecord',
                            data: medicalRecord,
                            success: function (data) {

                                window.location.pathname = '/MedicalRecord';

                            },
                            error: function () {
                                $.notify("Thêm bệnh án thất bại", { position: "top", autoHideDelay: 2000, className: "error" });
                            }
                        })

                    },
                    error: function (customer) {
                        $.notify("Thêm chi tiết toa thuốc thất bại", { position: "top", autoHideDelay: 2000, className: "error" });

                    }
                })

            },
            error: function () {
                $.notify("Thêm toa thuốc thất bại", { position: "top", autoHideDelay: 2000, className: "error" });

            }
        })


    })




});

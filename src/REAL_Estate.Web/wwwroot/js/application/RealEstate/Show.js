$(document).ready(function () {
    $('#Country').change(function () {
        const country = $(this).val();
        if (country) {
            $.get(`/domain/RealEstate/GetCities/${country}`, function (data) {
                $('#City').removeAttr('disabled').html('<option value="">Select City</option>' +
                    data.map(city => `<option value="${city.value}">${city.text}</option>`).join(''));
                $('#Region').attr('disabled', 'disabled').html('<option value="">Select Region</option>');
            });
        } else {
            $('#City').attr('disabled', 'disabled').html('<option value="">Select City</option>');
            $('#Region').attr('disabled', 'disabled').html('<option value="">Select Region</option>');
        }
    });
    
    $('#City').change(function () {
        const city = $(this).val();
        if (city) {
            $.get(`/domain/RealEstate/GetRegions/${city}`, function (data) {
                $('#Region').removeAttr('disabled').html('<option value="">Select Region</option>' +
                    data.map(region => `<option value="${region.value}">${region.text}</option>`).join(''));
            });
        } else {
            $('#Region').attr('disabled', 'disabled').html('<option value="">Select Region</option>');
        }
    });
});

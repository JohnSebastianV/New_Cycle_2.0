<script>
    document.addEventListener("DOMContentLoaded", function() {
        const passwordField = document.querySelector("#Contraseña");
    const togglePasswordButton = document.querySelector("#togglePassword");

    togglePasswordButton.addEventListener("click", function() {
            if (passwordField.type === "password") {
        passwordField.type = "text";
            } else {
        passwordField.type = "password";
            }
        });
    });
</script>

package CS1;

public class UserValidator {

    private Cryptographer cryptographer;

    public boolean checkPassword(String userName, String password) {
        User user = UserGateway.findByName(userName);

        if (user != null) {

            String codedPhrase = user.getPhraseEncodedByPassword();

            String phrase = cryptographer.decrypt(codedPhrase, password);

            if ("Valid Password".equals(phrase)) {

                session.initialize();

                return true;
            }


        }
        
    
        return false;
    }


}
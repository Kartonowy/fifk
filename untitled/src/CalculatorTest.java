import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.*;

import java.util.stream.Stream;

class CalculatorTest {
    @Test
    public void testAdd(){
        Calculator calc = new Calculator();
        assert calc.add(1,2) == 3;
    }

    @ParameterizedTest
    @CsvSource({"30, 30, 60"})
    public void testAddParams(int a, int b, int expected){
        Calculator calc = new Calculator();
        assert calc.add(a,b) == expected;
    }

    @ParameterizedTest
    @MethodSource("feedArguments")
    public void testAddMethod(int a, int b, int expected) {
        Calculator calc = new Calculator();
        assert calc.add(a, b) == expected;
    }
    public static Stream<Arguments> feedArguments() {
        return Stream.of(
                Arguments.arguments(15, 15, 30),
                Arguments.arguments(15, -15, 0),
                Arguments.arguments(15, 115, 130),
                Arguments.arguments(34, 35, 69)
        );
    }
}
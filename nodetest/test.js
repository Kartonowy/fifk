import assert from 'node:assert'
import test, { describe, it } from 'node:test'
import { gcd_rec, qsort } from './main.js'

test('gcd test 1', () => {
    assert.equal(gcd_rec(12, 2), 2)
})

test('gcd test 2', () => {
    assert.equal(gcd_rec(57, 23), 1)
})

test('gcd test 3', () => {
    assert.equal(gcd_rec(120, 20), 20)
})

describe('qs test', () => {
    it('uno', () => {
        assert.equal(qsort([4, 2, 0]), [0, 2, 4])
    });

    it('dos', () => {
        assert.equal(qsort([4, 2]), [2, 4])
    });

    describe('nested', () => {
        it('tres', () => {
            assert.equal(qsort([2, 1, 3, 7]), [1, 2, 3, 7])
        });
        it('quatro', () => {
            assert.deepEqual(qsort([1, 3, 3, 7]), [1, 3, 3, 7])
        });
    })
})

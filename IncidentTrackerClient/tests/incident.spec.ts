import { test, expect } from '@playwright/test';

test('Create and resolve an incident', async ({ page }) => {
  const incidentTitle = `Test ${Date.now()}`;

  await page.goto('http://localhost:3000');

  await page.fill('input[placeholder="Incident title"]', incidentTitle);
  await page.click('button:has-text("Create")');

  await expect(page.getByText(incidentTitle)).toBeVisible();

  await page.getByRole('button', { name: 'Resolve' }).first().click();

  await expect(page.getByText(incidentTitle).locator('..')).toContainText('Resolved');

  console.log('E2E test passed!');
});